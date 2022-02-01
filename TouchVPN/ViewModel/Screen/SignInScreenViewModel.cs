using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Backend.UserApi;
using Hydra.Sdk.Windows;
using Mystique.Auth;
using Mystique.Infrastructure.MystiqueSettings;
using Mystique.Infrastructure.UserInfo;
using Mystique.Navigation.Extension;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using TouchVPN.Screen;

namespace TouchVPN.ViewModel.Screen
{
	// Token: 0x02000010 RID: 16
	public class SignInScreenViewModel : BindableBase
	{
		// Token: 0x060000AB RID: 171 RVA: 0x000039D3 File Offset: 0x00001BD3
		public SignInScreenViewModel(IRegionManager regionManager, IFirebaseAuthClient firebaseAuthClient, IHydraSdk hydraSdk, ISettingsProvider settingsProvider, IUserInfoProvider userInfoProvider, IBackendService backendService)
		{
			this.regionManager = regionManager;
			this.firebaseAuthClient = firebaseAuthClient;
			this.hydraSdk = hydraSdk;
			this.settingsProvider = settingsProvider;
			this.userInfoProvider = userInfoProvider;
			this.backendService = backendService;
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060000AC RID: 172 RVA: 0x00003A08 File Offset: 0x00001C08
		// (set) Token: 0x060000AD RID: 173 RVA: 0x00003A10 File Offset: 0x00001C10
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

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060000AE RID: 174 RVA: 0x00003A25 File Offset: 0x00001C25
		// (set) Token: 0x060000AF RID: 175 RVA: 0x00003A2D File Offset: 0x00001C2D
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

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060000B0 RID: 176 RVA: 0x00003A42 File Offset: 0x00001C42
		// (set) Token: 0x060000B1 RID: 177 RVA: 0x00003A4A File Offset: 0x00001C4A
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

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060000B2 RID: 178 RVA: 0x00003A60 File Offset: 0x00001C60
		public ICommand NavigateToPasswordResetScreenCommand
		{
			get
			{
				ICommand result;
				if ((result = this.navigateToPasswordResetScreenCommand) == null)
				{
					result = (this.navigateToPasswordResetScreenCommand = new DelegateCommand(delegate()
					{
						this.regionManager.Navigate("Main");
					}));
				}
				return result;
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060000B3 RID: 179 RVA: 0x00003A94 File Offset: 0x00001C94
		public ICommand LoginCommand
		{
			get
			{
				ICommand result;
				if ((result = this.loginCommand) == null)
				{
					result = (this.loginCommand = new DelegateCommand<object>(delegate(object passwordBox)
					{
						SignInScreenViewModel.<<get_LoginCommand>b__25_0>d <<get_LoginCommand>b__25_0>d;
						<<get_LoginCommand>b__25_0>d.<>t__builder = AsyncVoidMethodBuilder.Create();
						<<get_LoginCommand>b__25_0>d.<>4__this = this;
						<<get_LoginCommand>b__25_0>d.passwordBox = passwordBox;
						<<get_LoginCommand>b__25_0>d.<>1__state = -1;
						<<get_LoginCommand>b__25_0>d.<>t__builder.Start<SignInScreenViewModel.<<get_LoginCommand>b__25_0>d>(ref <<get_LoginCommand>b__25_0>d);
					}));
				}
				return result;
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060000B4 RID: 180 RVA: 0x00003AC8 File Offset: 0x00001CC8
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

		// Token: 0x060000B5 RID: 181 RVA: 0x00003AFC File Offset: 0x00001CFC
		private Task Login(PasswordBox passwordBox)
		{
			SignInScreenViewModel.<Login>d__28 <Login>d__;
			<Login>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<Login>d__.<>4__this = this;
			<Login>d__.passwordBox = passwordBox;
			<Login>d__.<>1__state = -1;
			<Login>d__.<>t__builder.Start<SignInScreenViewModel.<Login>d__28>(ref <Login>d__);
			return <Login>d__.<>t__builder.Task;
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00003B48 File Offset: 0x00001D48
		private Task SaveUserInfo(string accessToken)
		{
			SignInScreenViewModel.<SaveUserInfo>d__29 <SaveUserInfo>d__;
			<SaveUserInfo>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<SaveUserInfo>d__.<>4__this = this;
			<SaveUserInfo>d__.accessToken = accessToken;
			<SaveUserInfo>d__.<>1__state = -1;
			<SaveUserInfo>d__.<>t__builder.Start<SignInScreenViewModel.<SaveUserInfo>d__29>(ref <SaveUserInfo>d__);
			return <SaveUserInfo>d__.<>t__builder.Task;
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00003B94 File Offset: 0x00001D94
		private Task<string> GetIdentityToken(PasswordBox passwordBox)
		{
			SignInScreenViewModel.<GetIdentityToken>d__30 <GetIdentityToken>d__;
			<GetIdentityToken>d__.<>t__builder = AsyncTaskMethodBuilder<string>.Create();
			<GetIdentityToken>d__.<>4__this = this;
			<GetIdentityToken>d__.passwordBox = passwordBox;
			<GetIdentityToken>d__.<>1__state = -1;
			<GetIdentityToken>d__.<>t__builder.Start<SignInScreenViewModel.<GetIdentityToken>d__30>(ref <GetIdentityToken>d__);
			return <GetIdentityToken>d__.<>t__builder.Task;
		}

		// Token: 0x04000055 RID: 85
		private readonly IRegionManager regionManager;

		// Token: 0x04000056 RID: 86
		private readonly IFirebaseAuthClient firebaseAuthClient;

		// Token: 0x04000057 RID: 87
		private readonly IHydraSdk hydraSdk;

		// Token: 0x04000058 RID: 88
		private readonly ISettingsProvider settingsProvider;

		// Token: 0x04000059 RID: 89
		private readonly IUserInfoProvider userInfoProvider;

		// Token: 0x0400005A RID: 90
		private readonly IBackendService backendService;

		// Token: 0x0400005B RID: 91
		private ICommand navigateToPasswordResetScreenCommand;

		// Token: 0x0400005C RID: 92
		private ICommand loginCommand;

		// Token: 0x0400005D RID: 93
		private ICommand continueCommand;

		// Token: 0x0400005E RID: 94
		private bool errorDialogVisible;

		// Token: 0x0400005F RID: 95
		private string email;

		// Token: 0x04000060 RID: 96
		private string errorDialogDescription;
	}
}
