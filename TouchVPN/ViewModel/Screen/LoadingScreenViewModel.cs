using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Mystique.Analytics;
using Mystique.Infrastructure.ApplicationInfo;
using Mystique.Infrastructure.MystiqueSettings;
using Mystique.Infrastructure.RemoteConfig;
using Mystique.Infrastructure.UserInfo;
using Mystique.Navigation.Extension;
using Mystique.Update.Client;
using Mystique.Update.Client.EventArgs;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using TouchVPN.Control;
using TouchVPN.Exception;
using TouchVPN.Properties;
using TouchVPN.Screen;
using TouchVPN.Service;

namespace TouchVPN.ViewModel.Screen
{
	// Token: 0x0200000C RID: 12
	public class LoadingScreenViewModel : BindableBase, INavigationAware
	{
		// Token: 0x0600007D RID: 125 RVA: 0x00003324 File Offset: 0x00001524
		public LoadingScreenViewModel(IApplicationInfoProvider applicationVersionProvider, ISettingsProvider settingsProvider, IRegionManager regionManager, IUserInfoProvider userInfoProvider, IRemoteConfigProvider remoteConfigProvider, IUpdateService updateService, IBackendDataService backendDataService, IAnalyticsSender analyticsSender)
		{
			this.applicationVersionProvider = applicationVersionProvider;
			this.settingsProvider = settingsProvider;
			this.regionManager = regionManager;
			this.userInfoProvider = userInfoProvider;
			this.remoteConfigProvider = remoteConfigProvider;
			this.backendDataService = backendDataService;
			this.updateService = updateService;
			this.analyticsSender = analyticsSender;
			this.updateService.StartUpdateServiceListener();
			this.updateService.UpdateProgressChanged += this.UpdateServiceOnUpdateProgressChanged;
			this.updateService.DownloadFailed += this.UpdateServiceOnDownloadFailed;
			this.updateService.UpdateFinished += delegate(object s, EventArgs e)
			{
				LoadingScreenViewModel.UpdateServiceOnUpdateFinished();
			};
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x0600007E RID: 126 RVA: 0x000033D8 File Offset: 0x000015D8
		public ICommand CancelCommand
		{
			get
			{
				ICommand result;
				if ((result = this.cancelCommand) == null)
				{
					result = (this.cancelCommand = new DelegateCommand(delegate()
					{
						LoadingScreenViewModel.<>c.<<get_CancelCommand>b__18_0>d <<get_CancelCommand>b__18_0>d;
						<<get_CancelCommand>b__18_0>d.<>t__builder = AsyncVoidMethodBuilder.Create();
						<<get_CancelCommand>b__18_0>d.<>1__state = -1;
						<<get_CancelCommand>b__18_0>d.<>t__builder.Start<LoadingScreenViewModel.<>c.<<get_CancelCommand>b__18_0>d>(ref <<get_CancelCommand>b__18_0>d);
					}));
				}
				return result;
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x0600007F RID: 127 RVA: 0x0000341C File Offset: 0x0000161C
		public ICommand RetryCommand
		{
			get
			{
				ICommand result;
				if ((result = this.retryCommand) == null)
				{
					result = (this.retryCommand = new DelegateCommand(delegate()
					{
						LoadingScreenViewModel.<<get_RetryCommand>b__20_0>d <<get_RetryCommand>b__20_0>d;
						<<get_RetryCommand>b__20_0>d.<>t__builder = AsyncVoidMethodBuilder.Create();
						<<get_RetryCommand>b__20_0>d.<>4__this = this;
						<<get_RetryCommand>b__20_0>d.<>1__state = -1;
						<<get_RetryCommand>b__20_0>d.<>t__builder.Start<LoadingScreenViewModel.<<get_RetryCommand>b__20_0>d>(ref <<get_RetryCommand>b__20_0>d);
					}));
				}
				return result;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000080 RID: 128 RVA: 0x0000344D File Offset: 0x0000164D
		// (set) Token: 0x06000081 RID: 129 RVA: 0x00003455 File Offset: 0x00001655
		public string AppVersion
		{
			get
			{
				return this.appVersion;
			}
			set
			{
				this.SetProperty<string>(ref this.appVersion, value, "AppVersion");
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000082 RID: 130 RVA: 0x0000346A File Offset: 0x0000166A
		// (set) Token: 0x06000083 RID: 131 RVA: 0x00003472 File Offset: 0x00001672
		public bool ErrorDialogVisible
		{
			get
			{
				return this.errorDialogVisible;
			}
			set
			{
				this.SetProperty<bool>(ref this.errorDialogVisible, value, "ErrorDialogVisible");
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000084 RID: 132 RVA: 0x00003487 File Offset: 0x00001687
		// (set) Token: 0x06000085 RID: 133 RVA: 0x0000348F File Offset: 0x0000168F
		public bool IsUpdateStarted
		{
			get
			{
				return this.isUpdateStarted;
			}
			set
			{
				this.SetProperty<bool>(ref this.isUpdateStarted, value, "IsUpdateStarted");
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000086 RID: 134 RVA: 0x000034A4 File Offset: 0x000016A4
		// (set) Token: 0x06000087 RID: 135 RVA: 0x000034AC File Offset: 0x000016AC
		public string DownloadUpdateFilePercentage
		{
			get
			{
				return this.downloadUpdateFilePercentage;
			}
			set
			{
				this.SetProperty<string>(ref this.downloadUpdateFilePercentage, value, "DownloadUpdateFilePercentage");
			}
		}

		// Token: 0x06000088 RID: 136 RVA: 0x000034C4 File Offset: 0x000016C4
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			LoadingScreenViewModel.<OnNavigatedTo>d__33 <OnNavigatedTo>d__;
			<OnNavigatedTo>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnNavigatedTo>d__.<>4__this = this;
			<OnNavigatedTo>d__.<>1__state = -1;
			<OnNavigatedTo>d__.<>t__builder.Start<LoadingScreenViewModel.<OnNavigatedTo>d__33>(ref <OnNavigatedTo>d__);
		}

		// Token: 0x06000089 RID: 137 RVA: 0x000034FB File Offset: 0x000016FB
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x0600008A RID: 138 RVA: 0x000034FE File Offset: 0x000016FE
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00003500 File Offset: 0x00001700
		private static void UpdateServiceOnUpdateFinished()
		{
			Application.Current.Dispatcher.Invoke(delegate()
			{
				Process.Start(Application.ResourceAssembly.Location);
				Application.Current.Shutdown();
			});
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00003530 File Offset: 0x00001730
		private Task SafeInitialize()
		{
			LoadingScreenViewModel.<SafeInitialize>d__37 <SafeInitialize>d__;
			<SafeInitialize>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<SafeInitialize>d__.<>4__this = this;
			<SafeInitialize>d__.<>1__state = -1;
			<SafeInitialize>d__.<>t__builder.Start<LoadingScreenViewModel.<SafeInitialize>d__37>(ref <SafeInitialize>d__);
			return <SafeInitialize>d__.<>t__builder.Task;
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00003574 File Offset: 0x00001774
		private Task Initialize()
		{
			LoadingScreenViewModel.<Initialize>d__38 <Initialize>d__;
			<Initialize>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<Initialize>d__.<>4__this = this;
			<Initialize>d__.<>1__state = -1;
			<Initialize>d__.<>t__builder.Start<LoadingScreenViewModel.<Initialize>d__38>(ref <Initialize>d__);
			return <Initialize>d__.<>t__builder.Task;
		}

		// Token: 0x0600008E RID: 142 RVA: 0x000035B8 File Offset: 0x000017B8
		private void Navigate()
		{
			if (this.isFirstLaunch)
			{
				this.regionManager.Navigate("Shell");
				return;
			}
			this.regionManager.Navigate("Shell");
			if (this.userInfoProvider.TrafficExceeded)
			{
				this.regionManager.Navigate("Main");
				return;
			}
			this.regionManager.Navigate("Main");
		}

		// Token: 0x0600008F RID: 143 RVA: 0x0000361C File Offset: 0x0000181C
		private Task InitializeAppData()
		{
			LoadingScreenViewModel.<InitializeAppData>d__40 <InitializeAppData>d__;
			<InitializeAppData>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<InitializeAppData>d__.<>4__this = this;
			<InitializeAppData>d__.<>1__state = -1;
			<InitializeAppData>d__.<>t__builder.Start<LoadingScreenViewModel.<InitializeAppData>d__40>(ref <InitializeAppData>d__);
			return <InitializeAppData>d__.<>t__builder.Task;
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00003660 File Offset: 0x00001860
		private Task Retry()
		{
			LoadingScreenViewModel.<Retry>d__41 <Retry>d__;
			<Retry>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<Retry>d__.<>4__this = this;
			<Retry>d__.<>1__state = -1;
			<Retry>d__.<>t__builder.Start<LoadingScreenViewModel.<Retry>d__41>(ref <Retry>d__);
			return <Retry>d__.<>t__builder.Task;
		}

		// Token: 0x06000091 RID: 145 RVA: 0x000036A3 File Offset: 0x000018A3
		private void UpdateServiceOnUpdateProgressChanged(object sender, UpdateProgressChangedEventArgs e)
		{
			this.DownloadUpdateFilePercentage = string.Format(CultureInfo.InvariantCulture, Resources.LoadingScreen_DownloadUpdateFilePercentage, e.Percentage);
		}

		// Token: 0x06000092 RID: 146 RVA: 0x000036C5 File Offset: 0x000018C5
		private void UpdateServiceOnDownloadFailed(object sender, EventArgs e)
		{
			this.IsUpdateStarted = false;
			this.Navigate();
		}

		// Token: 0x04000039 RID: 57
		private readonly IApplicationInfoProvider applicationVersionProvider;

		// Token: 0x0400003A RID: 58
		private readonly ISettingsProvider settingsProvider;

		// Token: 0x0400003B RID: 59
		private readonly IRegionManager regionManager;

		// Token: 0x0400003C RID: 60
		private readonly IUserInfoProvider userInfoProvider;

		// Token: 0x0400003D RID: 61
		private readonly IRemoteConfigProvider remoteConfigProvider;

		// Token: 0x0400003E RID: 62
		private readonly IUpdateService updateService;

		// Token: 0x0400003F RID: 63
		private readonly IBackendDataService backendDataService;

		// Token: 0x04000040 RID: 64
		private readonly IAnalyticsSender analyticsSender;

		// Token: 0x04000041 RID: 65
		private ICommand cancelCommand;

		// Token: 0x04000042 RID: 66
		private ICommand retryCommand;

		// Token: 0x04000043 RID: 67
		private string appVersion;

		// Token: 0x04000044 RID: 68
		private string downloadUpdateFilePercentage;

		// Token: 0x04000045 RID: 69
		private bool errorDialogVisible;

		// Token: 0x04000046 RID: 70
		private bool isUpdateStarted;

		// Token: 0x04000047 RID: 71
		private bool isFirstLaunch;

		// Token: 0x04000048 RID: 72
		private ResponseException responseException;
	}
}
