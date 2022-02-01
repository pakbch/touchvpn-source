using System;
using System.Windows.Input;
using Hydra.Sdk.Windows;
using Hydra.Sdk.Windows.Enum;
using Hydra.Sdk.Windows.EventArgs;
using Mystique.Infrastructure.MystiqueSettings;
using Mystique.Infrastructure.UserInfo;
using Mystique.Navigation.Extension;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using TouchVPN.Control;
using TouchVPN.Event;
using TouchVPN.Screen;

namespace TouchVPN.ViewModel.Control
{
	// Token: 0x02000013 RID: 19
	public class MainMenuViewModel : BindableBase
	{
		// Token: 0x060000D3 RID: 211 RVA: 0x000040E4 File Offset: 0x000022E4
		public MainMenuViewModel(IRegionManager regionManager, IHydraSdk hydraSdk, ISettingsProvider settingsProvider, IUserInfoProvider userInfoProvider)
		{
			this.regionManager = regionManager;
			this.hydraSdk = hydraSdk;
			this.settingsProvider = settingsProvider;
			this.userInfoProvider = userInfoProvider;
			this.hydraSdk.VpnConnectionStateChanged += delegate(object s, ConnectionStateChangedEventArgs e)
			{
				this.VpnConnectionState = e.State;
			};
			this.VpnConnectionState = VpnConnectionState.Disconnected;
			this.IsUnlimited = this.userInfoProvider.IsUnlimited;
			SubscriptionWatchdog.Owned += this.SubscriptionWatchdogOnOwned;
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060000D4 RID: 212 RVA: 0x00004154 File Offset: 0x00002354
		public ICommand NavigateToHomeScreenCommand
		{
			get
			{
				ICommand result;
				if ((result = this.navigateToHomeScreenCommand) == null)
				{
					result = (this.navigateToHomeScreenCommand = new DelegateCommand(new Action(this.NavigateToHomeScreen)));
				}
				return result;
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060000D5 RID: 213 RVA: 0x00004188 File Offset: 0x00002388
		public ICommand NavigateToAccountScreenCommand
		{
			get
			{
				ICommand result;
				if ((result = this.navigateToAccountScreenCommand) == null)
				{
					result = (this.navigateToAccountScreenCommand = new DelegateCommand(new Action(this.NavigateToAccountScreen)));
				}
				return result;
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060000D6 RID: 214 RVA: 0x000041BC File Offset: 0x000023BC
		public ICommand NavigateToAboutScreenCommand
		{
			get
			{
				ICommand result;
				if ((result = this.navigateToAboutScreenCommand) == null)
				{
					result = (this.navigateToAboutScreenCommand = new DelegateCommand(delegate()
					{
						this.regionManager.Navigate("Main");
					}));
				}
				return result;
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060000D7 RID: 215 RVA: 0x000041F0 File Offset: 0x000023F0
		public ICommand NavigateToSubscriptionScreenCommand
		{
			get
			{
				ICommand result;
				if ((result = this.navigateToSubscriptionScreenCommand) == null)
				{
					result = (this.navigateToSubscriptionScreenCommand = new DelegateCommand(delegate()
					{
						this.regionManager.Navigate("Main");
					}));
				}
				return result;
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060000D8 RID: 216 RVA: 0x00004224 File Offset: 0x00002424
		public ICommand NavigateToSettingsScreenCommand
		{
			get
			{
				ICommand result;
				if ((result = this.navigateToSettingsScreenCommand) == null)
				{
					result = (this.navigateToSettingsScreenCommand = new DelegateCommand(delegate()
					{
						this.regionManager.Navigate("Main");
					}));
				}
				return result;
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060000D9 RID: 217 RVA: 0x00004258 File Offset: 0x00002458
		public ICommand NavigateToSupportScreenCommand
		{
			get
			{
				ICommand result;
				if ((result = this.navigateToSupportScreenCommand) == null)
				{
					result = (this.navigateToSupportScreenCommand = new DelegateCommand(delegate()
					{
						this.regionManager.Navigate("Main");
					}));
				}
				return result;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060000DA RID: 218 RVA: 0x00004289 File Offset: 0x00002489
		// (set) Token: 0x060000DB RID: 219 RVA: 0x00004291 File Offset: 0x00002491
		public VpnConnectionState VpnConnectionState
		{
			get
			{
				return this.vpnConnectionState;
			}
			set
			{
				this.SetProperty<VpnConnectionState>(ref this.vpnConnectionState, value, "VpnConnectionState");
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060000DC RID: 220 RVA: 0x000042A6 File Offset: 0x000024A6
		// (set) Token: 0x060000DD RID: 221 RVA: 0x000042AE File Offset: 0x000024AE
		public bool IsUnlimited
		{
			get
			{
				return this.isUnlimited;
			}
			set
			{
				this.SetProperty<bool>(ref this.isUnlimited, value, "IsUnlimited");
			}
		}

		// Token: 0x060000DE RID: 222 RVA: 0x000042C3 File Offset: 0x000024C3
		private void NavigateToAccountScreen()
		{
			if (this.settingsProvider.IsSignedIn())
			{
				this.regionManager.Navigate("Main");
				return;
			}
			this.regionManager.Navigate("Main");
		}

		// Token: 0x060000DF RID: 223 RVA: 0x000042F3 File Offset: 0x000024F3
		private void NavigateToHomeScreen()
		{
			if (this.userInfoProvider.TrafficExceeded)
			{
				this.regionManager.Navigate("Main");
				return;
			}
			this.regionManager.Navigate("Main");
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00004323 File Offset: 0x00002523
		private void SubscriptionWatchdogOnOwned(object sender, bool e)
		{
			this.IsUnlimited = e;
			base.RaisePropertyChanged("IsUnlimited");
		}

		// Token: 0x04000073 RID: 115
		private readonly IRegionManager regionManager;

		// Token: 0x04000074 RID: 116
		private readonly IHydraSdk hydraSdk;

		// Token: 0x04000075 RID: 117
		private readonly ISettingsProvider settingsProvider;

		// Token: 0x04000076 RID: 118
		private readonly IUserInfoProvider userInfoProvider;

		// Token: 0x04000077 RID: 119
		private ICommand navigateToAccountScreenCommand;

		// Token: 0x04000078 RID: 120
		private ICommand navigateToHomeScreenCommand;

		// Token: 0x04000079 RID: 121
		private ICommand navigateToAboutScreenCommand;

		// Token: 0x0400007A RID: 122
		private ICommand navigateToSubscriptionScreenCommand;

		// Token: 0x0400007B RID: 123
		private ICommand navigateToSettingsScreenCommand;

		// Token: 0x0400007C RID: 124
		private ICommand navigateToSupportScreenCommand;

		// Token: 0x0400007D RID: 125
		private VpnConnectionState vpnConnectionState;

		// Token: 0x0400007E RID: 126
		private bool isUnlimited;
	}
}
