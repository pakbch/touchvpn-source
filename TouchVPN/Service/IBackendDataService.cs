using System;
using System.Threading.Tasks;
using Backend.UserApi.Model.Nodes;

namespace TouchVPN.Service
{
	// Token: 0x02000017 RID: 23
	public interface IBackendDataService
	{
		// Token: 0x060000FA RID: 250
		Task InitializeRemoteConfig(Carrier carrier);

		// Token: 0x060000FB RID: 251
		Task InitializeNodes(Carrier carrier);

		// Token: 0x060000FC RID: 252
		Task InitializeTrafficInfo(Carrier carrier);

		// Token: 0x060000FD RID: 253
		Task LoginAnonymous();
	}
}
