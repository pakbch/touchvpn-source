using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Hydra.Sdk.Windows;
using Hydra.Sdk.Windows.Enum;
using Hydra.Sdk.Windows.EventArgs;
using Mystique.Infrastructure.ApplicationInfo;
using Mystique.Navigation;
using Mystique.Shared;
using Mystique.Storage.Sdk;
using Mystique.UI.Tray;
using Prism.Commands;
using Prism.Mvvm;
using TouchVPN.Screen;

namespace TouchVPN.ViewModel
{
	// Token: 0x02000007 RID: 7
	public class ShellViewModel : BindableBase
	{
		// Token: 0x0600001E RID: 30 RVA: 0x000025A4 File Offset: 0x000007A4
		public ShellViewModel(IHydraSdk hydraSdk, INodeStorage nodeStorage, ICommandLineArgsProvider commandLineArgsProvider)
		{
			this.hydraSdk = hydraSdk;
			this.nodeStorage = nodeStorage;
			NavigationWatchdog.Woof += this.NavigationWatchdogOnWoof;
			this.hydraSdk.VpnConnectionStateChanged += this.HydraSdkOnVpnConnectionStateChanged;
			this.TrayIconState = TrayIconState.Disconnected;
			this.globalAppColor = (SolidColorBrush)Application.Current.Resources["RedMediumLightShade"];
			Check.NotNull<ICommandLineArgsProvider>(commandLineArgsProvider, "commandLineArgsProvider");
			commandLineArgsProvider.FindArguments();
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600001F RID: 31 RVA: 0x00002624 File Offset: 0x00000824
		public ICommand ShowWindowCommand
		{
			get
			{
				ICommand result;
				if ((result = this.showWindowCommand) == null)
				{
					result = (this.showWindowCommand = new DelegateCommand(new Action(this.ShowWindow)));
				}
				return result;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000020 RID: 32 RVA: 0x00002658 File Offset: 0x00000858
		public ICommand ConnectCommand
		{
			get
			{
				ICommand result;
				if ((result = this.connectCommand) == null)
				{
					result = (this.connectCommand = new DelegateCommand(new Action(this.Connect)));
				}
				return result;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000021 RID: 33 RVA: 0x0000268C File Offset: 0x0000088C
		public ICommand DisconnectCommand
		{
			get
			{
				ICommand result;
				if ((result = this.disconnectCommand) == null)
				{
					result = (this.disconnectCommand = new DelegateCommand(new Action(this.Disconnect)));
				}
				return result;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000022 RID: 34 RVA: 0x000026BD File Offset: 0x000008BD
		// (set) Token: 0x06000023 RID: 35 RVA: 0x000026C5 File Offset: 0x000008C5
		public bool ConnectVisible
		{
			get
			{
				return this.connectVisible;
			}
			set
			{
				this.SetProperty<bool>(ref this.connectVisible, value, "ConnectVisible");
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000024 RID: 36 RVA: 0x000026DA File Offset: 0x000008DA
		// (set) Token: 0x06000025 RID: 37 RVA: 0x000026E2 File Offset: 0x000008E2
		public bool DisconnectVisible
		{
			get
			{
				return this.disconnectVisible;
			}
			set
			{
				this.SetProperty<bool>(ref this.disconnectVisible, value, "DisconnectVisible");
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000026 RID: 38 RVA: 0x000026F7 File Offset: 0x000008F7
		// (set) Token: 0x06000027 RID: 39 RVA: 0x000026FF File Offset: 0x000008FF
		public bool TitleBarVisible
		{
			get
			{
				return this.titleBarVisible;
			}
			set
			{
				this.SetProperty<bool>(ref this.titleBarVisible, value, "TitleBarVisible");
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000028 RID: 40 RVA: 0x00002714 File Offset: 0x00000914
		// (set) Token: 0x06000029 RID: 41 RVA: 0x0000271C File Offset: 0x0000091C
		public bool LogoVisible
		{
			get
			{
				return this.logoVisible;
			}
			set
			{
				this.SetProperty<bool>(ref this.logoVisible, value, "LogoVisible");
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600002A RID: 42 RVA: 0x00002731 File Offset: 0x00000931
		// (set) Token: 0x0600002B RID: 43 RVA: 0x00002739 File Offset: 0x00000939
		public TrayIconState TrayIconState
		{
			get
			{
				return this.trayIconState;
			}
			set
			{
				this.SetProperty<TrayIconState>(ref this.trayIconState, value, "TrayIconState");
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600002C RID: 44 RVA: 0x0000274E File Offset: 0x0000094E
		// (set) Token: 0x0600002D RID: 45 RVA: 0x00002756 File Offset: 0x00000956
		public Brush GlobalAppColor
		{
			get
			{
				return this.globalAppColor;
			}
			set
			{
				this.SetProperty<Brush>(ref this.globalAppColor, value, "GlobalAppColor");
			}
		}

		// Token: 0x0600002E RID: 46 RVA: 0x0000276B File Offset: 0x0000096B
		private void Connect()
		{
			this.hydraSdk.StartVpn(this.nodeStorage.SelectedNode);
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002784 File Offset: 0x00000984
		private void Disconnect()
		{
			this.hydraSdk.StopVpn();
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00002794 File Offset: 0x00000994
		private void NavigationWatchdogOnWoof(object sender, WatchdogEventArgs e)
		{
			if (e.RegionName != "Shell")
			{
				return;
			}
			bool flag = e.TargetScreen != typeof(LoadingScreen);
			this.LogoVisible = (flag && e.TargetScreen != typeof(PersonalDataAgreementScreen));
			this.TitleBarVisible = flag;
			this.ConnectVisible = flag;
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000027FC File Offset: 0x000009FC
		private void ShowWindow()
		{
			Application application = Application.Current;
			bool flag;
			if (application == null)
			{
				flag = true;
			}
			else
			{
				Window mainWindow = application.MainWindow;
				Visibility? visibility = (mainWindow != null) ? new Visibility?(mainWindow.Visibility) : null;
				Visibility visibility2 = Visibility.Visible;
				flag = !(visibility.GetValueOrDefault() == visibility2 & visibility != null);
			}
			if (flag)
			{
				Application application2 = Application.Current;
				if (application2 != null)
				{
					Window mainWindow2 = application2.MainWindow;
					if (mainWindow2 != null)
					{
						mainWindow2.Show();
					}
				}
			}
			Application application3 = Application.Current;
			bool flag2;
			if (application3 == null)
			{
				flag2 = true;
			}
			else
			{
				Window mainWindow3 = application3.MainWindow;
				WindowState? windowState = (mainWindow3 != null) ? new WindowState?(mainWindow3.WindowState) : null;
				WindowState windowState2 = WindowState.Minimized;
				flag2 = !(windowState.GetValueOrDefault() == windowState2 & windowState != null);
			}
			if (flag2)
			{
				return;
			}
			Application application4 = Application.Current;
			if (((application4 != null) ? application4.MainWindow : null) != null)
			{
				Application.Current.MainWindow.WindowState = WindowState.Normal;
			}
			Application application5 = Application.Current;
			if (application5 == null)
			{
				return;
			}
			application5.MainWindow.Activate();
		}

		// Token: 0x06000032 RID: 50 RVA: 0x000028E8 File Offset: 0x00000AE8
		private void HydraSdkOnVpnConnectionStateChanged(object sender, ConnectionStateChangedEventArgs e)
		{
			switch (e.State)
			{
			case VpnConnectionState.Disconnected:
				this.TrayIconState = TrayIconState.Disconnected;
				this.ConnectVisible = true;
				this.DisconnectVisible = false;
				this.GlobalAppColor = (SolidColorBrush)Application.Current.Resources["RedMediumLightShade"];
				return;
			case VpnConnectionState.Connected:
				this.TrayIconState = TrayIconState.Connected;
				this.ConnectVisible = false;
				this.DisconnectVisible = true;
				this.GlobalAppColor = (SolidColorBrush)Application.Current.Resources["GreenCyanShade"];
				return;
			case VpnConnectionState.Connecting:
				this.TrayIconState = TrayIconState.Connecting;
				this.ConnectVisible = false;
				this.DisconnectVisible = false;
				this.GlobalAppColor = (SolidColorBrush)Application.Current.Resources["RedMediumLightShade"];
				return;
			case VpnConnectionState.Disconnecting:
				this.TrayIconState = TrayIconState.Disconnecting;
				this.ConnectVisible = false;
				this.DisconnectVisible = false;
				this.GlobalAppColor = (SolidColorBrush)Application.Current.Resources["RedMediumLightShade"];
				return;
			default:
				throw new ArgumentOutOfRangeException("e");
			}
		}

		// Token: 0x04000003 RID: 3
		private readonly IHydraSdk hydraSdk;

		// Token: 0x04000004 RID: 4
		private readonly INodeStorage nodeStorage;

		// Token: 0x04000005 RID: 5
		private ICommand connectCommand;

		// Token: 0x04000006 RID: 6
		private ICommand disconnectCommand;

		// Token: 0x04000007 RID: 7
		private ICommand showWindowCommand;

		// Token: 0x04000008 RID: 8
		private TrayIconState trayIconState;

		// Token: 0x04000009 RID: 9
		private Brush globalAppColor;

		// Token: 0x0400000A RID: 10
		private bool titleBarVisible;

		// Token: 0x0400000B RID: 11
		private bool logoVisible;

		// Token: 0x0400000C RID: 12
		private bool connectVisible;

		// Token: 0x0400000D RID: 13
		private bool disconnectVisible;
	}
}
