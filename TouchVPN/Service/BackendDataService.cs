using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Backend.UserApi.Model.Nodes;
using Hydra.Sdk.Windows;
using Mystique.Infrastructure.ApplicationInfo;
using Mystique.Infrastructure.MystiqueSettings;
using Mystique.Infrastructure.RemoteConfig;
using Mystique.Infrastructure.UserInfo;
using Mystique.Storage.Sdk;

namespace TouchVPN.Service
{
	// Token: 0x02000016 RID: 22
	internal class BackendDataService : IBackendDataService
	{
		// Token: 0x060000F4 RID: 244 RVA: 0x00004580 File Offset: 0x00002780
		internal BackendDataService(IHydraSdk hydraSdk, INodeStorage nodeStorage, IUserInfoProvider userInfoProvider, IRemoteConfigProvider remoteConfigProvider, ISettingsProvider settingsProvider, ICommandLineArgsProvider commandLineArgsProvider)
		{
			this.hydraSdk = hydraSdk;
			this.nodeStorage = nodeStorage;
			this.userInfoProvider = userInfoProvider;
			this.remoteConfigProvider = remoteConfigProvider;
			this.commandLineArgsProvider = commandLineArgsProvider;
			this.settingsProvider = settingsProvider;
			this.settingsProvider.TokenUpdated += this.OnTokenUpdated;
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x000045D8 File Offset: 0x000027D8
		public Task InitializeRemoteConfig(Carrier carrier)
		{
			BackendDataService.<InitializeRemoteConfig>d__7 <InitializeRemoteConfig>d__;
			<InitializeRemoteConfig>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<InitializeRemoteConfig>d__.<>4__this = this;
			<InitializeRemoteConfig>d__.carrier = carrier;
			<InitializeRemoteConfig>d__.<>1__state = -1;
			<InitializeRemoteConfig>d__.<>t__builder.Start<BackendDataService.<InitializeRemoteConfig>d__7>(ref <InitializeRemoteConfig>d__);
			return <InitializeRemoteConfig>d__.<>t__builder.Task;
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00004624 File Offset: 0x00002824
		public Task InitializeNodes(Carrier carrier)
		{
			BackendDataService.<InitializeNodes>d__8 <InitializeNodes>d__;
			<InitializeNodes>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<InitializeNodes>d__.<>4__this = this;
			<InitializeNodes>d__.carrier = carrier;
			<InitializeNodes>d__.<>1__state = -1;
			<InitializeNodes>d__.<>t__builder.Start<BackendDataService.<InitializeNodes>d__8>(ref <InitializeNodes>d__);
			return <InitializeNodes>d__.<>t__builder.Task;
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00004670 File Offset: 0x00002870
		public Task InitializeTrafficInfo(Carrier carrier)
		{
			BackendDataService.<InitializeTrafficInfo>d__9 <InitializeTrafficInfo>d__;
			<InitializeTrafficInfo>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<InitializeTrafficInfo>d__.<>4__this = this;
			<InitializeTrafficInfo>d__.carrier = carrier;
			<InitializeTrafficInfo>d__.<>1__state = -1;
			<InitializeTrafficInfo>d__.<>t__builder.Start<BackendDataService.<InitializeTrafficInfo>d__9>(ref <InitializeTrafficInfo>d__);
			return <InitializeTrafficInfo>d__.<>t__builder.Task;
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x000046BC File Offset: 0x000028BC
		public Task LoginAnonymous()
		{
			BackendDataService.<LoginAnonymous>d__10 <LoginAnonymous>d__;
			<LoginAnonymous>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<LoginAnonymous>d__.<>4__this = this;
			<LoginAnonymous>d__.<>1__state = -1;
			<LoginAnonymous>d__.<>t__builder.Start<BackendDataService.<LoginAnonymous>d__10>(ref <LoginAnonymous>d__);
			return <LoginAnonymous>d__.<>t__builder.Task;
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00004700 File Offset: 0x00002900
		private void OnTokenUpdated(object sender, EventArgs e)
		{
			BackendDataService.<OnTokenUpdated>d__11 <OnTokenUpdated>d__;
			<OnTokenUpdated>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnTokenUpdated>d__.<>4__this = this;
			<OnTokenUpdated>d__.<>1__state = -1;
			<OnTokenUpdated>d__.<>t__builder.Start<BackendDataService.<OnTokenUpdated>d__11>(ref <OnTokenUpdated>d__);
		}

		// Token: 0x04000087 RID: 135
		private readonly IHydraSdk hydraSdk;

		// Token: 0x04000088 RID: 136
		private readonly INodeStorage nodeStorage;

		// Token: 0x04000089 RID: 137
		private readonly IUserInfoProvider userInfoProvider;

		// Token: 0x0400008A RID: 138
		private readonly IRemoteConfigProvider remoteConfigProvider;

		// Token: 0x0400008B RID: 139
		private readonly ISettingsProvider settingsProvider;

		// Token: 0x0400008C RID: 140
		private readonly ICommandLineArgsProvider commandLineArgsProvider;
	}
}
