using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using Backend.UserApi;
using Hydra.Sdk.Windows;
using Hydra.Sdk.Windows.IoC;
using Hydra.Sdk.Windows.Logger;
using Hydra.Sdk.Windows.Network.Rules;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Mystique.Analytics;
using Mystique.Application;
using Mystique.Auth;
using Mystique.Configuration;
using Mystique.Infrastructure.ApplicationInfo;
using Mystique.Infrastructure.EnvironmentInfo;
using Mystique.Infrastructure.MystiqueSettings;
using Mystique.Infrastructure.RemoteConfig;
using Mystique.Infrastructure.Startup;
using Mystique.Infrastructure.UserInfo;
using Mystique.LoggerConfiguration.Sdk;
using Mystique.Navigation.Extension;
using Mystique.Shared;
using Mystique.Storage.Sdk;
using Mystique.Update.Client;
using Prism.Ioc;
using Prism.Regions;
using Prism.Unity;
using TouchVPN.Control;
using TouchVPN.Screen;
using TouchVPN.Service;

namespace TouchVPN
{
	// Token: 0x02000004 RID: 4
	public partial class App : PrismApplication
	{
		// Token: 0x0600000B RID: 11 RVA: 0x00002101 File Offset: 0x00000301
		protected override Window CreateShell()
		{
			return base.Container.Resolve<TouchVpnShell>();
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002110 File Offset: 0x00000310
		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			Check.NotNull<IContainerRegistry>(containerRegistry, "containerRegistry");
			App.RegisterServices(containerRegistry);
			string deviceId = base.Container.Resolve<ISettingsProvider>().EnsureDeviceId();
			this.RegisterAnalyticSender(containerRegistry, deviceId);
			this.RegisterUpdateService(containerRegistry);
			App.RegisterScreens(containerRegistry);
			App.RegisterHydraSdk(containerRegistry, deviceId);
		}

		// Token: 0x0600000D RID: 13 RVA: 0x0000215B File Offset: 0x0000035B
		protected override void OnInitialized()
		{
			base.OnInitialized();
			IRegionManager regionManager = base.Container.Resolve<IRegionManager>();
			regionManager.RegisterViewWithRegion("MainMenu", typeof(MainMenu));
			regionManager.Navigate("Shell");
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002190 File Offset: 0x00000390
		protected override void OnStartup(StartupEventArgs e)
		{
			NLogConfiguration.InitLoggerConfig();
			this.SetupExceptionHandling();
			HydraLogger.AddHandler(new LoggerListener());
			HydraLogger.IsEnabled = true;
			ApplicationRunner.RunSingleInstance("BF9C45F7-5230-4E9A-9444-105AB024CE3B");
			AppCenter.Start("e28d22d0-9de0-4ba5-84d4-5fe34c6ff075", new Type[]
			{
				typeof(Analytics),
				typeof(Crashes)
			});
			base.OnStartup(e);
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000021F4 File Offset: 0x000003F4
		private static void RegisterServices(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterSingleton(typeof(IApplicationInfoProvider), typeof(ApplicationInfoProvider));
			containerRegistry.RegisterSingleton(typeof(ISettingsProvider), typeof(RegistrySettingsProvider));
			containerRegistry.RegisterSingleton(typeof(INodeStorage), typeof(NodeStorage));
			containerRegistry.RegisterSingleton(typeof(IUserInfoProvider), typeof(UserInfoProvider));
			containerRegistry.RegisterInstance(typeof(IFirebaseAuthClient), new FirebaseAuthClient(FirebaseConfiguration.AppKey, FirebaseConfiguration.AuthCallbackUrl));
			containerRegistry.RegisterSingleton(typeof(IUserInfoProvider), typeof(UserInfoProvider));
			containerRegistry.RegisterInstance(typeof(IBackendService), new BackendService(new Uri(VpnSdkConfiguration.BackendAddress)));
			containerRegistry.RegisterSingleton(typeof(IRemoteConfigProvider), typeof(RemoteConfigProvider));
			containerRegistry.RegisterSingleton(typeof(IStartupProvider), typeof(StartupProvider));
			containerRegistry.RegisterSingleton(typeof(IEnvironmentInfoProvider), typeof(EnvironmentInfoProvider));
			containerRegistry.RegisterSingleton(typeof(ICommandLineArgsProvider), typeof(CommandLineArgsProvider));
			containerRegistry.RegisterSingleton(typeof(IBackendDataService), typeof(BackendDataService));
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002350 File Offset: 0x00000550
		private static void RegisterScreens(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterScreenForNavigation<LoadingScreen>();
			containerRegistry.RegisterScreenForNavigation<MainScreen>();
			containerRegistry.RegisterScreenForNavigation<HomeScreen>();
			containerRegistry.RegisterScreenForNavigation<AccountScreen>();
			containerRegistry.RegisterScreenForNavigation<AboutScreen>();
			containerRegistry.RegisterScreenForNavigation<SettingsScreen>();
			containerRegistry.RegisterScreenForNavigation<SupportScreen>();
			containerRegistry.RegisterScreenForNavigation<SubscriptionScreen>();
			containerRegistry.RegisterScreenForNavigation<SignInScreen>();
			containerRegistry.RegisterScreenForNavigation<VirtualLocation>();
			containerRegistry.RegisterScreenForNavigation<DebugScreen>();
			containerRegistry.RegisterScreenForNavigation<TrafficExceeded>();
			containerRegistry.RegisterScreenForNavigation<PersonalDataAgreementScreen>();
			containerRegistry.RegisterScreenForNavigation<PasswordResetScreen>();
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000023B4 File Offset: 0x000005B4
		private static void RegisterHydraSdk(IContainerRegistry containerRegistry, string deviceId)
		{
			BackendServerConfiguration backendConfiguration = new BackendServerConfiguration(VpnSdkConfiguration.CarrierId, VpnSdkConfiguration.BackendAddress, deviceId);
			HydraWindowsConfiguration hydraConfiguration = new HydraWindowsConfiguration(VpnSdkConfiguration.ServiceName, new Dictionary<int, IConnectionRule>());
			new HydraWindowsBootstrapper().Bootstrap(backendConfiguration, hydraConfiguration);
			containerRegistry.RegisterInstance(HydraIoc.Container.Resolve<IHydraSdk>());
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000023FF File Offset: 0x000005FF
		private void RegisterUpdateService(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterSingleton(typeof(IUpdateService), typeof(UpdateService));
			base.Container.Resolve<IUpdateService>().InitUpdateServiceProperties(ApplicationConfiguration.Name, UpdateServiceConfiguration.UpdateServicePipeName, UpdateServiceConfiguration.UpdateServiceListenerPipeName);
		}

		// Token: 0x06000013 RID: 19 RVA: 0x0000243C File Offset: 0x0000063C
		private void RegisterAnalyticSender(IContainerRegistry containerRegistry, string deviceId)
		{
			IApplicationInfoProvider applicationInfoProvider = base.Container.Resolve<IApplicationInfoProvider>();
			FileVersion[] array = new FileVersion[4];
			RuntimeHelpers.InitializeArray(array, fieldof(<PrivateImplementationDetails>.BAED642339816AFFB3FE8719792D0E4CE82F12DB72B7373D244EAA65445800FE).FieldHandle);
			string version = applicationInfoProvider.GetVersion(array);
			containerRegistry.RegisterInstance(typeof(IAnalyticsSender), new GoogleAnalyticsSender(ApplicationConfiguration.TrackingId, deviceId, ApplicationConfiguration.Name, version));
		}
	}
}
