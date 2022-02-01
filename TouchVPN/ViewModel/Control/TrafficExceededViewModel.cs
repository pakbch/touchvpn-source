using System;
using System.Windows.Input;
using Mystique.Navigation.Extension;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using TouchVPN.Screen;

namespace TouchVPN.ViewModel.Control
{
	// Token: 0x02000014 RID: 20
	public class TrafficExceededViewModel : BindableBase
	{
		// Token: 0x060000E6 RID: 230 RVA: 0x0000438D File Offset: 0x0000258D
		public TrafficExceededViewModel(IRegionManager regionManager)
		{
			this.regionManager = regionManager;
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060000E7 RID: 231 RVA: 0x0000439C File Offset: 0x0000259C
		public ICommand UpgradeToPremiumCommand
		{
			get
			{
				ICommand result;
				if ((result = this.upgradeToPremiumCommand) == null)
				{
					result = (this.upgradeToPremiumCommand = new DelegateCommand(delegate()
					{
						this.regionManager.Navigate("Main");
					}));
				}
				return result;
			}
		}

		// Token: 0x0400007F RID: 127
		private readonly IRegionManager regionManager;

		// Token: 0x04000080 RID: 128
		private ICommand upgradeToPremiumCommand;
	}
}
