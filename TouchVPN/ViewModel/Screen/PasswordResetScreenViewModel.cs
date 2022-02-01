using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Mystique.Auth;
using Mystique.Navigation.Extension;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using TouchVPN.Screen;

namespace TouchVPN.ViewModel.Screen
{
	// Token: 0x0200000D RID: 13
	public class PasswordResetScreenViewModel : BindableBase
	{
		// Token: 0x06000094 RID: 148 RVA: 0x0000370B File Offset: 0x0000190B
		public PasswordResetScreenViewModel(IRegionManager regionManager, IFirebaseAuthClient firebaseAuthClient)
		{
			this.regionManager = regionManager;
			this.firebaseAuthClient = firebaseAuthClient;
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000095 RID: 149 RVA: 0x00003724 File Offset: 0x00001924
		public ICommand NavigateToAuthSelectionScreenCommand
		{
			get
			{
				ICommand result;
				if ((result = this.navigateToAuthSelectionScreenCommand) == null)
				{
					result = (this.navigateToAuthSelectionScreenCommand = new DelegateCommand(delegate()
					{
						this.regionManager.Navigate("Main");
					}));
				}
				return result;
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000096 RID: 150 RVA: 0x00003758 File Offset: 0x00001958
		public ICommand PasswordResetCommand
		{
			get
			{
				ICommand result;
				if ((result = this.passwordResetCommand) == null)
				{
					result = (this.passwordResetCommand = new DelegateCommand(delegate()
					{
						PasswordResetScreenViewModel.<<get_PasswordResetCommand>b__10_0>d <<get_PasswordResetCommand>b__10_0>d;
						<<get_PasswordResetCommand>b__10_0>d.<>t__builder = AsyncVoidMethodBuilder.Create();
						<<get_PasswordResetCommand>b__10_0>d.<>4__this = this;
						<<get_PasswordResetCommand>b__10_0>d.<>1__state = -1;
						<<get_PasswordResetCommand>b__10_0>d.<>t__builder.Start<PasswordResetScreenViewModel.<<get_PasswordResetCommand>b__10_0>d>(ref <<get_PasswordResetCommand>b__10_0>d);
					}));
				}
				return result;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000097 RID: 151 RVA: 0x00003789 File Offset: 0x00001989
		// (set) Token: 0x06000098 RID: 152 RVA: 0x00003791 File Offset: 0x00001991
		public string Email
		{
			get
			{
				return this.email;
			}
			set
			{
				this.SetProperty<string>(ref this.email, value, "Email");
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000099 RID: 153 RVA: 0x000037A6 File Offset: 0x000019A6
		// (set) Token: 0x0600009A RID: 154 RVA: 0x000037AE File Offset: 0x000019AE
		public bool LinkSent
		{
			get
			{
				return this.linkSent;
			}
			set
			{
				this.SetProperty<bool>(ref this.linkSent, value, "LinkSent");
			}
		}

		// Token: 0x0600009B RID: 155 RVA: 0x000037C4 File Offset: 0x000019C4
		private Task Reset()
		{
			PasswordResetScreenViewModel.<Reset>d__17 <Reset>d__;
			<Reset>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<Reset>d__.<>4__this = this;
			<Reset>d__.<>1__state = -1;
			<Reset>d__.<>t__builder.Start<PasswordResetScreenViewModel.<Reset>d__17>(ref <Reset>d__);
			return <Reset>d__.<>t__builder.Task;
		}

		// Token: 0x04000049 RID: 73
		private readonly IRegionManager regionManager;

		// Token: 0x0400004A RID: 74
		private readonly IFirebaseAuthClient firebaseAuthClient;

		// Token: 0x0400004B RID: 75
		private ICommand navigateToAuthSelectionScreenCommand;

		// Token: 0x0400004C RID: 76
		private ICommand passwordResetCommand;

		// Token: 0x0400004D RID: 77
		private string email;

		// Token: 0x0400004E RID: 78
		private bool linkSent;
	}
}
