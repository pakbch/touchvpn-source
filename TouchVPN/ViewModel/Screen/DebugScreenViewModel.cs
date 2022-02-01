using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Mystique.Infrastructure.ApplicationInfo;
using Mystique.Infrastructure.EnvironmentInfo;
using Mystique.Infrastructure.MystiqueSettings;
using Mystique.Infrastructure.RemoteConfig;
using Mystique.Navigation.Extension;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using TouchVPN.Screen;

namespace TouchVPN.ViewModel.Screen
{
	// Token: 0x0200000A RID: 10
	public class DebugScreenViewModel : BindableBase, INavigationAware
	{
		// Token: 0x06000047 RID: 71 RVA: 0x00002C37 File Offset: 0x00000E37
		public DebugScreenViewModel(ISettingsProvider settingsProvider, IRemoteConfigProvider remoteConfigProvider, IApplicationInfoProvider applicationVersionProvider, IEnvironmentInfoProvider environmentInfoProvider, IRegionManager regionManager)
		{
			this.settingsProvider = settingsProvider;
			this.remoteConfigProvider = remoteConfigProvider;
			this.applicationVersionProvider = applicationVersionProvider;
			this.environmentInfoProvider = environmentInfoProvider;
			this.regionManager = regionManager;
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000048 RID: 72 RVA: 0x00002C64 File Offset: 0x00000E64
		public ICommand CrashCommand
		{
			get
			{
				ICommand result;
				if ((result = this.crashCommand) == null)
				{
					result = (this.crashCommand = new DelegateCommand(new Action(this.Crash)));
				}
				return result;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000049 RID: 73 RVA: 0x00002C98 File Offset: 0x00000E98
		public ICommand CloseCommand
		{
			get
			{
				ICommand result;
				if ((result = this.closeCommand) == null)
				{
					result = (this.closeCommand = new DelegateCommand(new Action(this.Close)));
				}
				return result;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600004A RID: 74 RVA: 0x00002CC9 File Offset: 0x00000EC9
		// (set) Token: 0x0600004B RID: 75 RVA: 0x00002CD1 File Offset: 0x00000ED1
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

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600004C RID: 76 RVA: 0x00002CE6 File Offset: 0x00000EE6
		// (set) Token: 0x0600004D RID: 77 RVA: 0x00002CEE File Offset: 0x00000EEE
		public string Build
		{
			get
			{
				return this.build;
			}
			set
			{
				this.SetProperty<string>(ref this.build, value, "Build");
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600004E RID: 78 RVA: 0x00002D03 File Offset: 0x00000F03
		// (set) Token: 0x0600004F RID: 79 RVA: 0x00002D0B File Offset: 0x00000F0B
		public string Token
		{
			get
			{
				return this.token;
			}
			set
			{
				this.SetProperty<string>(ref this.token, value, "Token");
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000050 RID: 80 RVA: 0x00002D20 File Offset: 0x00000F20
		// (set) Token: 0x06000051 RID: 81 RVA: 0x00002D28 File Offset: 0x00000F28
		public string DeviceId
		{
			get
			{
				return this.deviceId;
			}
			set
			{
				this.SetProperty<string>(ref this.deviceId, value, "DeviceId");
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000052 RID: 82 RVA: 0x00002D3D File Offset: 0x00000F3D
		// (set) Token: 0x06000053 RID: 83 RVA: 0x00002D45 File Offset: 0x00000F45
		public string OsVersion
		{
			get
			{
				return this.operatingSystemVersion;
			}
			set
			{
				this.SetProperty<string>(ref this.operatingSystemVersion, value, "OsVersion");
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000054 RID: 84 RVA: 0x00002D5A File Offset: 0x00000F5A
		// (set) Token: 0x06000055 RID: 85 RVA: 0x00002D62 File Offset: 0x00000F62
		public string NetFrameworkVersion
		{
			get
			{
				return this.netFrameworkVersion;
			}
			set
			{
				this.SetProperty<string>(ref this.netFrameworkVersion, value, "NetFrameworkVersion");
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000056 RID: 86 RVA: 0x00002D77 File Offset: 0x00000F77
		// (set) Token: 0x06000057 RID: 87 RVA: 0x00002D7F File Offset: 0x00000F7F
		public string EdgeRuntimeVersion
		{
			get
			{
				return this.edgeRuntimeVersion;
			}
			set
			{
				this.SetProperty<string>(ref this.edgeRuntimeVersion, value, "EdgeRuntimeVersion");
			}
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00002D94 File Offset: 0x00000F94
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			DebugScreenViewModel.<OnNavigatedTo>d__40 <OnNavigatedTo>d__;
			<OnNavigatedTo>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnNavigatedTo>d__.<>4__this = this;
			<OnNavigatedTo>d__.<>1__state = -1;
			<OnNavigatedTo>d__.<>t__builder.Start<DebugScreenViewModel.<OnNavigatedTo>d__40>(ref <OnNavigatedTo>d__);
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00002DCB File Offset: 0x00000FCB
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00002DCE File Offset: 0x00000FCE
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00002DD0 File Offset: 0x00000FD0
		private void Crash()
		{
			throw new IOException("Crash");
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00002DDC File Offset: 0x00000FDC
		private void Close()
		{
			if (this.settingsProvider.IsSignedIn())
			{
				this.regionManager.Navigate("Main");
				return;
			}
			this.regionManager.Navigate("Main");
		}

		// Token: 0x0400001B RID: 27
		private readonly ISettingsProvider settingsProvider;

		// Token: 0x0400001C RID: 28
		private readonly IRemoteConfigProvider remoteConfigProvider;

		// Token: 0x0400001D RID: 29
		private readonly IApplicationInfoProvider applicationVersionProvider;

		// Token: 0x0400001E RID: 30
		private readonly IEnvironmentInfoProvider environmentInfoProvider;

		// Token: 0x0400001F RID: 31
		private readonly IRegionManager regionManager;

		// Token: 0x04000020 RID: 32
		private ICommand crashCommand;

		// Token: 0x04000021 RID: 33
		private ICommand closeCommand;

		// Token: 0x04000022 RID: 34
		private string appVersion;

		// Token: 0x04000023 RID: 35
		private string build;

		// Token: 0x04000024 RID: 36
		private string token;

		// Token: 0x04000025 RID: 37
		private string deviceId;

		// Token: 0x04000026 RID: 38
		private string operatingSystemVersion;

		// Token: 0x04000027 RID: 39
		private string netFrameworkVersion;

		// Token: 0x04000028 RID: 40
		private string edgeRuntimeVersion;
	}
}
