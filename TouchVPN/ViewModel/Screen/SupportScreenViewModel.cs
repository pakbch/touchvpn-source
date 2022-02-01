using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Windows.Input;
using Mystique.Configuration;
using Mystique.Infrastructure.ApplicationInfo;
using Mystique.Infrastructure.MystiqueSettings;
using Mystique.Infrastructure.RemoteConfig;
using Mystique.UI.Processing;
using Prism.Commands;
using Prism.Mvvm;
using TouchVPN.Properties;

namespace TouchVPN.ViewModel.Screen
{
	// Token: 0x02000012 RID: 18
	public class SupportScreenViewModel : BindableBase
	{
		// Token: 0x060000C7 RID: 199 RVA: 0x00003DFB File Offset: 0x00001FFB
		public SupportScreenViewModel(ISettingsProvider settingsProvider, IRemoteConfigProvider remoteConfigProvider, IApplicationInfoProvider applicationVersionProvider)
		{
			this.settingsProvider = settingsProvider;
			this.remoteConfigProvider = remoteConfigProvider;
			this.applicationVersionProvider = applicationVersionProvider;
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060000C8 RID: 200 RVA: 0x00003E18 File Offset: 0x00002018
		public ICommand SendQuestionCommand
		{
			get
			{
				ICommand result;
				if ((result = this.sendQuestionCommand) == null)
				{
					result = (this.sendQuestionCommand = new DelegateCommand(delegate()
					{
						this.SendQuestion();
					}));
				}
				return result;
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060000C9 RID: 201 RVA: 0x00003E4C File Offset: 0x0000204C
		public ICommand SendAnotherQuestionCommand
		{
			get
			{
				ICommand result;
				if ((result = this.sendAnotherQuestionCommand) == null)
				{
					result = (this.sendAnotherQuestionCommand = new DelegateCommand(new Action(this.SendAnotherQuestion)));
				}
				return result;
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060000CA RID: 202 RVA: 0x00003E7D File Offset: 0x0000207D
		// (set) Token: 0x060000CB RID: 203 RVA: 0x00003E85 File Offset: 0x00002085
		public string Question
		{
			get
			{
				return this.question;
			}
			set
			{
				this.SetProperty<string>(ref this.question, value, "Question");
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060000CC RID: 204 RVA: 0x00003E9A File Offset: 0x0000209A
		// (set) Token: 0x060000CD RID: 205 RVA: 0x00003EA2 File Offset: 0x000020A2
		public bool MessageSent
		{
			get
			{
				return this.messageSent;
			}
			set
			{
				this.SetProperty<bool>(ref this.messageSent, value, "MessageSent");
			}
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00003EB8 File Offset: 0x000020B8
		private void SendQuestion()
		{
			ProcessingWatchdog.PlayProcessing();
			string str = "mailto:" + string.Join(",", this.remoteConfigProvider.SupportEmailAddresses.ToArray<string>());
			string str2 = "?subject=" + Resources.SupportMail_Subject;
			string str3 = "&body=" + this.BuildEmailBody();
			Process.Start(str + str2 + str3);
			this.MessageSent = true;
			ProcessingWatchdog.StopProcessing();
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00003F28 File Offset: 0x00002128
		private string BuildEmailBody()
		{
			string value = (!string.IsNullOrEmpty(this.Question)) ? this.Question : Resources.SupportMail_DefaultFeedback;
			string version = this.applicationVersionProvider.GetVersion(new ProductVersion[]
			{
				ProductVersion.Major,
				ProductVersion.Minor,
				ProductVersion.Build
			});
			string version2 = this.applicationVersionProvider.GetVersion(new ProductVersion[]
			{
				ProductVersion.Revision
			});
			string str = this.settingsProvider.IsSignedIn() ? this.settingsProvider.GetAccessToken(TokenType.Registered) : this.settingsProvider.GetAccessToken(TokenType.Anonymous);
			return new StringBuilder().Append(value).Append(SupportScreenViewModel.EmailNewLine).Append(SupportScreenViewModel.EmailNewLine).Append(SupportScreenViewModel.EmailNewLine).Append(SupportScreenViewModel.EmailNewLine).Append(Resources.SupportMail_DoNotDelete).Append(SupportScreenViewModel.EmailNewLine).Append(Resources.SupportMail_Version + ": " + version).Append(SupportScreenViewModel.EmailNewLine).Append(Resources.SupportMail_Build + ": " + version2).Append(SupportScreenViewModel.EmailNewLine).Append(Resources.SupportMail_ProjectId + ": " + VpnSdkConfiguration.CarrierId).Append(SupportScreenViewModel.EmailNewLine).Append(Resources.SupportMail_Device + ": Windows").Append(SupportScreenViewModel.EmailNewLine).Append(string.Format("{0}: {1}", Resources.SupportMail_OS, Environment.OSVersion)).Append(SupportScreenViewModel.EmailNewLine).Append(Resources.SupportMail_Token + ": " + str).Append(SupportScreenViewModel.EmailNewLine).ToString();
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x000040B5 File Offset: 0x000022B5
		private void SendAnotherQuestion()
		{
			this.Question = string.Empty;
			this.MessageSent = false;
		}

		// Token: 0x0400006B RID: 107
		private static readonly string EmailNewLine = HttpUtility.UrlEncode(Environment.NewLine);

		// Token: 0x0400006C RID: 108
		private readonly ISettingsProvider settingsProvider;

		// Token: 0x0400006D RID: 109
		private readonly IRemoteConfigProvider remoteConfigProvider;

		// Token: 0x0400006E RID: 110
		private readonly IApplicationInfoProvider applicationVersionProvider;

		// Token: 0x0400006F RID: 111
		private ICommand sendQuestionCommand;

		// Token: 0x04000070 RID: 112
		private ICommand sendAnotherQuestionCommand;

		// Token: 0x04000071 RID: 113
		private string question;

		// Token: 0x04000072 RID: 114
		private bool messageSent;
	}
}
