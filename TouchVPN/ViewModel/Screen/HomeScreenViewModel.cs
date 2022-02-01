using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Hydra.Sdk.Windows;
using Hydra.Sdk.Windows.Enum;
using Hydra.Sdk.Windows.EventArgs;
using Mystique.Infrastructure.UserInfo;
using Mystique.Navigation.Extension;
using Mystique.Parser.Sdk;
using Mystique.Storage.Sdk;
using Mystique.UI.ConnectButton;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using TouchVPN.Control;
using TouchVPN.Event;

namespace TouchVPN.ViewModel.Screen
{
	// Token: 0x0200000B RID: 11
	public class HomeScreenViewModel : BindableBase, INavigationAware
	{
		// Token: 0x0600005D RID: 93 RVA: 0x00002E0C File Offset: 0x0000100C
		public HomeScreenViewModel(IHydraSdk hydraSdk, INodeStorage nodeStorage, IRegionManager regionManager, IUserInfoProvider userInfoProvider)
		{
			this.hydraSdk = hydraSdk;
			this.nodeStorage = nodeStorage;
			this.regionManager = regionManager;
			this.userInfoProvider = userInfoProvider;
			this.hydraSdk.VpnConnectionStateChanged += this.OnVpnConnectionStateChanged;
			this.hydraSdk.StatisticsChanged += this.OnStatisticsChanged;
			this.nodeStorage.NodesUpdated += this.NodeStorageOnNodesUpdated;
			this.vpnConnectionState = VpnConnectionState.Disconnected;
			this.isVirtualLocationSelectEnabled = (this.VpnConnectionState != VpnConnectionState.Connecting && this.VpnConnectionState != VpnConnectionState.Disconnecting);
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600005E RID: 94 RVA: 0x00002EA8 File Offset: 0x000010A8
		public ICommand ConnectCommand
		{
			get
			{
				ICommand result;
				if ((result = this.connectCommand) == null)
				{
					result = (this.connectCommand = new DelegateCommand(delegate()
					{
						HomeScreenViewModel.<<get_ConnectCommand>b__18_0>d <<get_ConnectCommand>b__18_0>d;
						<<get_ConnectCommand>b__18_0>d.<>t__builder = AsyncVoidMethodBuilder.Create();
						<<get_ConnectCommand>b__18_0>d.<>4__this = this;
						<<get_ConnectCommand>b__18_0>d.<>1__state = -1;
						<<get_ConnectCommand>b__18_0>d.<>t__builder.Start<HomeScreenViewModel.<<get_ConnectCommand>b__18_0>d>(ref <<get_ConnectCommand>b__18_0>d);
					}));
				}
				return result;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600005F RID: 95 RVA: 0x00002EDC File Offset: 0x000010DC
		public ICommand NavigateToVirtualLocationCommand
		{
			get
			{
				ICommand result;
				if ((result = this.navigateToVirtualLocationCommand) == null)
				{
					result = (this.navigateToVirtualLocationCommand = new DelegateCommand(new Action(this.NavigateToVirtualLocation)));
				}
				return result;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000060 RID: 96 RVA: 0x00002F0D File Offset: 0x0000110D
		// (set) Token: 0x06000061 RID: 97 RVA: 0x00002F15 File Offset: 0x00001115
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

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000062 RID: 98 RVA: 0x00002F2A File Offset: 0x0000112A
		// (set) Token: 0x06000063 RID: 99 RVA: 0x00002F32 File Offset: 0x00001132
		public AnimatedButtonState AnimatedButtonState
		{
			get
			{
				return this.animatedButtonState;
			}
			set
			{
				this.SetProperty<AnimatedButtonState>(ref this.animatedButtonState, value, "AnimatedButtonState");
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000064 RID: 100 RVA: 0x00002F47 File Offset: 0x00001147
		// (set) Token: 0x06000065 RID: 101 RVA: 0x00002F4F File Offset: 0x0000114F
		public long BytesReceived
		{
			get
			{
				return this.bytesReceived;
			}
			set
			{
				this.SetProperty<long>(ref this.bytesReceived, value, "BytesReceived");
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000066 RID: 102 RVA: 0x00002F64 File Offset: 0x00001164
		// (set) Token: 0x06000067 RID: 103 RVA: 0x00002F6C File Offset: 0x0000116C
		public Mystique.Parser.Sdk.VirtualLocation SelectedVpnNode
		{
			get
			{
				return this.selectedVpnNode;
			}
			set
			{
				this.SetProperty<Mystique.Parser.Sdk.VirtualLocation>(ref this.selectedVpnNode, value, "SelectedVpnNode");
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000068 RID: 104 RVA: 0x00002F81 File Offset: 0x00001181
		// (set) Token: 0x06000069 RID: 105 RVA: 0x00002F89 File Offset: 0x00001189
		public long BytesSent
		{
			get
			{
				return this.bytesSent;
			}
			set
			{
				this.SetProperty<long>(ref this.bytesSent, value, "BytesSent");
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x0600006A RID: 106 RVA: 0x00002F9E File Offset: 0x0000119E
		// (set) Token: 0x0600006B RID: 107 RVA: 0x00002FA6 File Offset: 0x000011A6
		public string CountryDisplayName
		{
			get
			{
				return this.countryDisplayName;
			}
			set
			{
				this.SetProperty<string>(ref this.countryDisplayName, value, "CountryDisplayName");
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x0600006C RID: 108 RVA: 0x00002FBB File Offset: 0x000011BB
		public long TrafficLimit
		{
			get
			{
				return this.userInfoProvider.TrafficLimit;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x0600006D RID: 109 RVA: 0x00002FC8 File Offset: 0x000011C8
		// (set) Token: 0x0600006E RID: 110 RVA: 0x00002FD0 File Offset: 0x000011D0
		public long TrafficRemaining
		{
			get
			{
				return this.trafficRemaining;
			}
			set
			{
				this.SetProperty<long>(ref this.trafficRemaining, value, "TrafficRemaining");
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600006F RID: 111 RVA: 0x00002FE5 File Offset: 0x000011E5
		// (set) Token: 0x06000070 RID: 112 RVA: 0x00002FED File Offset: 0x000011ED
		public bool IsVirtualLocationSelectEnabled
		{
			get
			{
				return this.isVirtualLocationSelectEnabled;
			}
			set
			{
				this.SetProperty<bool>(ref this.isVirtualLocationSelectEnabled, value, "IsVirtualLocationSelectEnabled");
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000071 RID: 113 RVA: 0x00003002 File Offset: 0x00001202
		// (set) Token: 0x06000072 RID: 114 RVA: 0x0000300A File Offset: 0x0000120A
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

		// Token: 0x06000073 RID: 115 RVA: 0x00003020 File Offset: 0x00001220
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			this.IsUnlimited = this.userInfoProvider.IsUnlimited;
			SubscriptionWatchdog.MakeOwn(this.userInfoProvider.IsUnlimited);
			Mystique.Parser.Sdk.VirtualLocation virtualLocation = this.nodeStorage.SelectedNode.ToVpnNodeModel();
			if (this.SelectedVpnNode != null && this.SelectedVpnNode.DisplayName.Equals(virtualLocation.DisplayName, StringComparison.OrdinalIgnoreCase) && this.SelectedVpnNode.ServerModel.Carrier.Token.Equals(virtualLocation.ServerModel.Carrier.Token, StringComparison.OrdinalIgnoreCase))
			{
				return;
			}
			this.SelectedVpnNode = null;
			this.SelectedVpnNode = virtualLocation;
			this.CountryDisplayName = this.SelectedVpnNode.DisplayName;
			this.TrafficRemaining = this.userInfoProvider.TrafficRemaining;
			this.Reconnect().ConfigureAwait(false);
		}

		// Token: 0x06000074 RID: 116 RVA: 0x000030EB File Offset: 0x000012EB
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x06000075 RID: 117 RVA: 0x000030EE File Offset: 0x000012EE
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
		}

		// Token: 0x06000076 RID: 118 RVA: 0x000030F0 File Offset: 0x000012F0
		public void NavigateToVirtualLocation()
		{
			this.regionManager.Navigate("Main");
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00003104 File Offset: 0x00001304
		private Task Connect()
		{
			HomeScreenViewModel.<Connect>d__54 <Connect>d__;
			<Connect>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<Connect>d__.<>4__this = this;
			<Connect>d__.<>1__state = -1;
			<Connect>d__.<>t__builder.Start<HomeScreenViewModel.<Connect>d__54>(ref <Connect>d__);
			return <Connect>d__.<>t__builder.Task;
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00003148 File Offset: 0x00001348
		private Task Reconnect()
		{
			HomeScreenViewModel.<Reconnect>d__55 <Reconnect>d__;
			<Reconnect>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<Reconnect>d__.<>4__this = this;
			<Reconnect>d__.<>1__state = -1;
			<Reconnect>d__.<>t__builder.Start<HomeScreenViewModel.<Reconnect>d__55>(ref <Reconnect>d__);
			return <Reconnect>d__.<>t__builder.Task;
		}

		// Token: 0x06000079 RID: 121 RVA: 0x0000318C File Offset: 0x0000138C
		private void OnVpnConnectionStateChanged(object s, ConnectionStateChangedEventArgs e)
		{
			this.VpnConnectionState = e.State;
			this.IsVirtualLocationSelectEnabled = (this.VpnConnectionState != VpnConnectionState.Connecting && this.VpnConnectionState != VpnConnectionState.Disconnecting);
			switch (this.VpnConnectionState)
			{
			case VpnConnectionState.Disconnected:
				this.AnimatedButtonState = AnimatedButtonState.Off;
				return;
			case VpnConnectionState.Connected:
				this.AnimatedButtonState = AnimatedButtonState.On;
				return;
			case VpnConnectionState.Connecting:
				this.AnimatedButtonState = AnimatedButtonState.Processing;
				return;
			case VpnConnectionState.Disconnecting:
				break;
			default:
				this.AnimatedButtonState = AnimatedButtonState.Off;
				break;
			}
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00003204 File Offset: 0x00001404
		private void OnStatisticsChanged(object s, VpnStatisticsChangedEventArgs e)
		{
			this.BytesSent = e.Data.BytesSent;
			this.BytesReceived = e.Data.BytesReceived;
			this.bytesReceivedDelta = e.Data.BytesReceived - this.bytesReceivedDelta;
			if (this.userInfoProvider.IsUnlimited)
			{
				return;
			}
			long num = this.TrafficRemaining - this.bytesReceivedDelta;
			if (num > 0L)
			{
				this.TrafficRemaining = num;
				return;
			}
			this.TrafficRemaining = 0L;
			this.userInfoProvider.TrafficExceeded = true;
			this.hydraSdk.StopVpn().ConfigureAwait(false);
			this.regionManager.Navigate("Main");
		}

		// Token: 0x0600007B RID: 123 RVA: 0x000032AC File Offset: 0x000014AC
		private void NodeStorageOnNodesUpdated(object sender, EventArgs e)
		{
			Mystique.Parser.Sdk.VirtualLocation virtualLocation = this.nodeStorage.SelectedNode.ToVpnNodeModel();
			this.SelectedVpnNode = null;
			this.SelectedVpnNode = virtualLocation;
			this.CountryDisplayName = this.SelectedVpnNode.DisplayName;
		}

		// Token: 0x04000029 RID: 41
		private readonly IHydraSdk hydraSdk;

		// Token: 0x0400002A RID: 42
		private readonly INodeStorage nodeStorage;

		// Token: 0x0400002B RID: 43
		private readonly IRegionManager regionManager;

		// Token: 0x0400002C RID: 44
		private readonly IUserInfoProvider userInfoProvider;

		// Token: 0x0400002D RID: 45
		private ICommand connectCommand;

		// Token: 0x0400002E RID: 46
		private ICommand navigateToVirtualLocationCommand;

		// Token: 0x0400002F RID: 47
		private VpnConnectionState vpnConnectionState;

		// Token: 0x04000030 RID: 48
		private AnimatedButtonState animatedButtonState;

		// Token: 0x04000031 RID: 49
		private Mystique.Parser.Sdk.VirtualLocation selectedVpnNode;

		// Token: 0x04000032 RID: 50
		private string countryDisplayName;

		// Token: 0x04000033 RID: 51
		private long trafficRemaining;

		// Token: 0x04000034 RID: 52
		private long bytesReceived;

		// Token: 0x04000035 RID: 53
		private long bytesSent;

		// Token: 0x04000036 RID: 54
		private long bytesReceivedDelta;

		// Token: 0x04000037 RID: 55
		private bool isVirtualLocationSelectEnabled;

		// Token: 0x04000038 RID: 56
		private bool isUnlimited;
	}
}
