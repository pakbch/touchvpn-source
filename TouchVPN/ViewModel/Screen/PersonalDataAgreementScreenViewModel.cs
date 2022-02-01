using System;
using System.Windows.Input;
using Mystique.Navigation.Extension;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using TouchVPN.Screen;

namespace TouchVPN.ViewModel.Screen
{
	// Token: 0x0200000E RID: 14
	public class PersonalDataAgreementScreenViewModel : BindableBase
	{
		// Token: 0x0600009E RID: 158 RVA: 0x00003853 File Offset: 0x00001A53
		public PersonalDataAgreementScreenViewModel(IRegionManager regionManager)
		{
			this.regionManager = regionManager;
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x0600009F RID: 159 RVA: 0x00003864 File Offset: 0x00001A64
		public ICommand NavigateToHomeScreenCommand
		{
			get
			{
				ICommand result;
				if ((result = this.navigateToHomeScreenCommand) == null)
				{
					result = (this.navigateToHomeScreenCommand = new DelegateCommand(delegate()
					{
						this.regionManager.Navigate("Shell");
						this.regionManager.Navigate("Main");
					}));
				}
				return result;
			}
		}

		// Token: 0x0400004F RID: 79
		private readonly IRegionManager regionManager;

		// Token: 0x04000050 RID: 80
		private ICommand navigateToHomeScreenCommand;
	}
}
