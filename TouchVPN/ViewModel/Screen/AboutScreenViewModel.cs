using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using Mystique.Infrastructure.ApplicationInfo;
using Mystique.Shared;
using Prism.Mvvm;
using TouchVPN.Properties;

namespace TouchVPN.ViewModel.Screen
{
	// Token: 0x02000008 RID: 8
	public class AboutScreenViewModel : BindableBase
	{
		// Token: 0x06000033 RID: 51 RVA: 0x000029F8 File Offset: 0x00000BF8
		public AboutScreenViewModel(IApplicationInfoProvider applicationVersionProvider)
		{
			Check.NotNull<IApplicationInfoProvider>(applicationVersionProvider, "applicationVersionProvider");
			ProductVersion[] array = new ProductVersion[4];
			RuntimeHelpers.InitializeArray(array, fieldof(<PrivateImplementationDetails>.BAED642339816AFFB3FE8719792D0E4CE82F12DB72B7373D244EAA65445800FE).FieldHandle);
			string version = applicationVersionProvider.GetVersion(array);
			this.appVersion = string.Format(CultureInfo.InvariantCulture, Resources.AboutScreen_Version, version);
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000034 RID: 52 RVA: 0x00002A44 File Offset: 0x00000C44
		// (set) Token: 0x06000035 RID: 53 RVA: 0x00002A4C File Offset: 0x00000C4C
		public string AppVersion
		{
			get
			{
				return this.appVersion;
			}
			set
			{
				this.SetProperty<string>(ref this.appVersion, value, "AppVersion");
			}
		}

		// Token: 0x0400000E RID: 14
		private string appVersion;
	}
}
