using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Backend.UserApi;
using Mystique.Infrastructure.ApplicationInfo;
using Mystique.Infrastructure.MystiqueSettings;
using Mystique.Infrastructure.RemoteConfig;
using Mystique.Infrastructure.UserInfo;
using Mystique.UI.Processing;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace TouchVPN.ViewModel.Screen
{
	// Token: 0x02000011 RID: 17
	public class SubscriptionScreenViewModel : BindableBase
	{
		// Token: 0x060000BB RID: 187 RVA: 0x00003C3C File Offset: 0x00001E3C
		public SubscriptionScreenViewModel(ISettingsProvider settingsProvider, IUserInfoProvider userInfoProvider, IRegionManager regionManager, IBackendService backendService, IRemoteConfigProvider remoteConfigProvider, ICommandLineArgsProvider commandLineArgsProvider)
		{
			this.settingsProvider = settingsProvider;
			this.userInfoProvider = userInfoProvider;
			this.regionManager = regionManager;
			this.backendService = backendService;
			this.remoteConfigProvider = remoteConfigProvider;
			this.commandLineArgsProvider = commandLineArgsProvider;
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060000BC RID: 188 RVA: 0x00003C74 File Offset: 0x00001E74
		public ICommand ContinueCommand
		{
			get
			{
				ICommand result;
				if ((result = this.continueCommand) == null)
				{
					result = (this.continueCommand = new DelegateCommand(delegate()
					{
						this.ErrorDialogVisible = false;
					}));
				}
				return result;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060000BD RID: 189 RVA: 0x00003CA8 File Offset: 0x00001EA8
		public ICommand PurchaseCommand
		{
			get
			{
				ICommand result;
				if ((result = this.purchaseCommand) == null)
				{
					result = (this.purchaseCommand = new DelegateCommand(delegate()
					{
						SubscriptionScreenViewModel.<<get_PurchaseCommand>b__14_0>d <<get_PurchaseCommand>b__14_0>d;
						<<get_PurchaseCommand>b__14_0>d.<>t__builder = AsyncVoidMethodBuilder.Create();
						<<get_PurchaseCommand>b__14_0>d.<>4__this = this;
						<<get_PurchaseCommand>b__14_0>d.<>1__state = -1;
						<<get_PurchaseCommand>b__14_0>d.<>t__builder.Start<SubscriptionScreenViewModel.<<get_PurchaseCommand>b__14_0>d>(ref <<get_PurchaseCommand>b__14_0>d);
					}));
				}
				return result;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000BE RID: 190 RVA: 0x00003CD9 File Offset: 0x00001ED9
		// (set) Token: 0x060000BF RID: 191 RVA: 0x00003CE1 File Offset: 0x00001EE1
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

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000C0 RID: 192 RVA: 0x00003CF6 File Offset: 0x00001EF6
		// (set) Token: 0x060000C1 RID: 193 RVA: 0x00003CFE File Offset: 0x00001EFE
		public string ErrorDialogDescription
		{
			get
			{
				return this.errorDialogDescription;
			}
			set
			{
				this.SetProperty<string>(ref this.errorDialogDescription, value, "ErrorDialogDescription");
			}
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00003D14 File Offset: 0x00001F14
		private Task ShowCheckoutDialog()
		{
			SubscriptionScreenViewModel.<ShowCheckoutDialog>d__21 <ShowCheckoutDialog>d__;
			<ShowCheckoutDialog>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<ShowCheckoutDialog>d__.<>4__this = this;
			<ShowCheckoutDialog>d__.<>1__state = -1;
			<ShowCheckoutDialog>d__.<>t__builder.Start<SubscriptionScreenViewModel.<ShowCheckoutDialog>d__21>(ref <ShowCheckoutDialog>d__);
			return <ShowCheckoutDialog>d__.<>t__builder.Task;
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00003D58 File Offset: 0x00001F58
		private Task<Uri> BuildCheckoutPageUrl(string accessToken)
		{
			SubscriptionScreenViewModel.<BuildCheckoutPageUrl>d__22 <BuildCheckoutPageUrl>d__;
			<BuildCheckoutPageUrl>d__.<>t__builder = AsyncTaskMethodBuilder<Uri>.Create();
			<BuildCheckoutPageUrl>d__.<>4__this = this;
			<BuildCheckoutPageUrl>d__.accessToken = accessToken;
			<BuildCheckoutPageUrl>d__.<>1__state = -1;
			<BuildCheckoutPageUrl>d__.<>t__builder.Start<SubscriptionScreenViewModel.<BuildCheckoutPageUrl>d__22>(ref <BuildCheckoutPageUrl>d__);
			return <BuildCheckoutPageUrl>d__.<>t__builder.Task;
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00003DA3 File Offset: 0x00001FA3
		private void ShowError(string errorMessage)
		{
			ProcessingWatchdog.StopProcessing();
			this.ErrorDialogVisible = true;
			this.ErrorDialogDescription = errorMessage;
		}

		// Token: 0x04000061 RID: 97
		private readonly ISettingsProvider settingsProvider;

		// Token: 0x04000062 RID: 98
		private readonly IUserInfoProvider userInfoProvider;

		// Token: 0x04000063 RID: 99
		private readonly IRegionManager regionManager;

		// Token: 0x04000064 RID: 100
		private readonly IBackendService backendService;

		// Token: 0x04000065 RID: 101
		private readonly IRemoteConfigProvider remoteConfigProvider;

		// Token: 0x04000066 RID: 102
		private readonly ICommandLineArgsProvider commandLineArgsProvider;

		// Token: 0x04000067 RID: 103
		private ICommand purchaseCommand;

		// Token: 0x04000068 RID: 104
		private ICommand continueCommand;

		// Token: 0x04000069 RID: 105
		private bool errorDialogVisible;

		// Token: 0x0400006A RID: 106
		private string errorDialogDescription;
	}
}
