using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Backend.UserApi.Model.Nodes;
using Mystique.Infrastructure.UserInfo;
using Mystique.Navigation.Extension;
using Mystique.Parser.Sdk;
using Mystique.Storage.Sdk;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using TouchVPN.Screen;

namespace TouchVPN.ViewModel.Control
{
	// Token: 0x02000015 RID: 21
	public class VirtualLocationViewModel : BindableBase
	{
		// Token: 0x060000E9 RID: 233 RVA: 0x000043E0 File Offset: 0x000025E0
		public VirtualLocationViewModel(INodeStorage nodeStorage, IRegionManager regionManager, IUserInfoProvider userInfoProvider)
		{
			this.nodeStorage = nodeStorage;
			this.nodeStorage.NodesUpdated += this.NodeStorageOnNodesUpdated;
			this.regionManager = regionManager;
			this.userInfoProvider = userInfoProvider;
			this.UpdateNodeList();
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060000EA RID: 234 RVA: 0x00004430 File Offset: 0x00002630
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

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060000EB RID: 235 RVA: 0x00004461 File Offset: 0x00002661
		public ObservableCollection<VirtualLocation> AllNodeModels { get; } = new ObservableCollection<VirtualLocation>();

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060000EC RID: 236 RVA: 0x00004469 File Offset: 0x00002669
		// (set) Token: 0x060000ED RID: 237 RVA: 0x00004471 File Offset: 0x00002671
		public VirtualLocation SelectedVpnNode
		{
			get
			{
				return this.selectedVpnNode;
			}
			set
			{
				this.SetProperty<VirtualLocation>(ref this.selectedVpnNode, value, "SelectedVpnNode");
			}
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00004486 File Offset: 0x00002686
		private void NavigateToHomeScreen()
		{
			if (this.SelectedVpnNode != null)
			{
				this.nodeStorage.UpdateSelectedNode(this.SelectedVpnNode.ServerModel);
			}
			this.regionManager.Navigate("Main");
		}

		// Token: 0x060000EF RID: 239 RVA: 0x000044B6 File Offset: 0x000026B6
		private void NodeStorageOnNodesUpdated(object sender, EventArgs e)
		{
			this.UpdateNodeList();
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x000044BE File Offset: 0x000026BE
		private void UpdateNodeList()
		{
			Application.Current.Dispatcher.Invoke(delegate()
			{
				this.AllNodeModels.Clear();
				this.AllNodeModels.AddRange(from x in this.nodeStorage.Nodes
				select x.ToVpnNodeModel(this.userInfoProvider.IsUnlimited));
				this.SelectedVpnNode = (this.AllNodeModels.FirstOrDefault((VirtualLocation x) => x.Equals(this.nodeStorage.SelectedNode.ToVpnNodeModel(this.userInfoProvider.IsUnlimited))) ?? this.AllNodeModels.FirstOrDefault<VirtualLocation>());
			});
		}

		// Token: 0x04000081 RID: 129
		private readonly INodeStorage nodeStorage;

		// Token: 0x04000082 RID: 130
		private readonly IRegionManager regionManager;

		// Token: 0x04000083 RID: 131
		private readonly IUserInfoProvider userInfoProvider;

		// Token: 0x04000084 RID: 132
		private ICommand navigateToHomeScreenCommand;

		// Token: 0x04000085 RID: 133
		private VirtualLocation selectedVpnNode;
	}
}
