using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using Hydra.Sdk.Windows;
using Mystique.Infrastructure.MystiqueSettings;
using Mystique.Infrastructure.UserInfo;
using Mystique.Navigation.Extension;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using TouchVPN.Screen;
using TouchVPN.Service;

namespace TouchVPN.ViewModel.Screen
{
	// Token: 0x02000009 RID: 9
	public class AccountScreenViewModel : BindableBase, INavigationAware
	{
		// Token: 0x06000036 RID: 54 RVA: 0x00002A61 File Offset: 0x00000C61
		public AccountScreenViewModel(IRegionManager regionManager, IHydraSdk hydraSdk, ISettingsProvider settingsProvider, IUserInfoProvider userInfoProvider, IBackendDataService backendDataService)
		{
			this.regionManager = regionManager;
			this.hydraSdk = hydraSdk;
			this.settingsProvider = settingsProvider;
			this.userInfoProvider = userInfoProvider;
			this.backendDataService = backendDataService;
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000037 RID: 55 RVA: 0x00002A90 File Offset: 0x00000C90
		public ICommand SignOutCommand
		{
			get
			{
				ICommand result;
				if ((result = this.signOutCommand) == null)
				{
					result = (this.signOutCommand = new DelegateCommand(delegate()
					{
						AccountScreenViewModel.<<get_SignOutCommand>b__14_0>d <<get_SignOutCommand>b__14_0>d;
						<<get_SignOutCommand>b__14_0>d.<>t__builder = AsyncVoidMethodBuilder.Create();
						<<get_SignOutCommand>b__14_0>d.<>4__this = this;
						<<get_SignOutCommand>b__14_0>d.<>1__state = -1;
						<<get_SignOutCommand>b__14_0>d.<>t__builder.Start<AccountScreenViewModel.<<get_SignOutCommand>b__14_0>d>(ref <<get_SignOutCommand>b__14_0>d);
					}));
				}
				return result;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000038 RID: 56 RVA: 0x00002AC4 File Offset: 0x00000CC4
		public ICommand NavigateToDebugScreenCommand
		{
			get
			{
				ICommand result;
				if ((result = this.navigateToDebugScreenCommand) == null)
				{
					result = (this.navigateToDebugScreenCommand = new DelegateCommand(new Action(this.NavigateToDebugScreen)));
				}
				return result;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000039 RID: 57 RVA: 0x00002AF5 File Offset: 0x00000CF5
		// (set) Token: 0x0600003A RID: 58 RVA: 0x00002AFD File Offset: 0x00000CFD
		public string DisplayName
		{
			get
			{
				return this.displayName;
			}
			set
			{
				this.SetProperty<string>(ref this.displayName, value, "DisplayName");
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600003B RID: 59 RVA: 0x00002B12 File Offset: 0x00000D12
		// (set) Token: 0x0600003C RID: 60 RVA: 0x00002B1A File Offset: 0x00000D1A
		public string AccountPlan
		{
			get
			{
				return this.accountPlan;
			}
			set
			{
				this.SetProperty<string>(ref this.accountPlan, value, "AccountPlan");
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600003D RID: 61 RVA: 0x00002B2F File Offset: 0x00000D2F
		// (set) Token: 0x0600003E RID: 62 RVA: 0x00002B37 File Offset: 0x00000D37
		public ImageSource PhotoPath
		{
			get
			{
				return this.photoPath;
			}
			set
			{
				this.SetProperty<ImageSource>(ref this.photoPath, value, "PhotoPath");
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600003F RID: 63 RVA: 0x00002B4C File Offset: 0x00000D4C
		// (set) Token: 0x06000040 RID: 64 RVA: 0x00002B54 File Offset: 0x00000D54
		public bool IsPhotoExists
		{
			get
			{
				return this.isPhotoExists;
			}
			set
			{
				this.SetProperty<bool>(ref this.isPhotoExists, value, "IsPhotoExists");
			}
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002B6C File Offset: 0x00000D6C
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			AccountScreenViewModel.<OnNavigatedTo>d__29 <OnNavigatedTo>d__;
			<OnNavigatedTo>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnNavigatedTo>d__.<>4__this = this;
			<OnNavigatedTo>d__.<>1__state = -1;
			<OnNavigatedTo>d__.<>t__builder.Start<AccountScreenViewModel.<OnNavigatedTo>d__29>(ref <OnNavigatedTo>d__);
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00002BA3 File Offset: 0x00000DA3
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00002BA6 File Offset: 0x00000DA6
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00002BA8 File Offset: 0x00000DA8
		private void NavigateToDebugScreen()
		{
			this.regionManager.Navigate("Main");
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00002BBC File Offset: 0x00000DBC
		private Task SignOut()
		{
			AccountScreenViewModel.<SignOut>d__33 <SignOut>d__;
			<SignOut>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<SignOut>d__.<>4__this = this;
			<SignOut>d__.<>1__state = -1;
			<SignOut>d__.<>t__builder.Start<AccountScreenViewModel.<SignOut>d__33>(ref <SignOut>d__);
			return <SignOut>d__.<>t__builder.Task;
		}

		// Token: 0x0400000F RID: 15
		private readonly IRegionManager regionManager;

		// Token: 0x04000010 RID: 16
		private readonly IHydraSdk hydraSdk;

		// Token: 0x04000011 RID: 17
		private readonly ISettingsProvider settingsProvider;

		// Token: 0x04000012 RID: 18
		private readonly IUserInfoProvider userInfoProvider;

		// Token: 0x04000013 RID: 19
		private readonly IBackendDataService backendDataService;

		// Token: 0x04000014 RID: 20
		private ICommand signOutCommand;

		// Token: 0x04000015 RID: 21
		private ICommand navigateToDebugScreenCommand;

		// Token: 0x04000016 RID: 22
		private ImageSource photoPath;

		// Token: 0x04000017 RID: 23
		private UserInformation userInfo;

		// Token: 0x04000018 RID: 24
		private string displayName;

		// Token: 0x04000019 RID: 25
		private string accountPlan;

		// Token: 0x0400001A RID: 26
		private bool isPhotoExists;
	}
}
