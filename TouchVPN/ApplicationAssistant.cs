using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace TouchVPN
{
	// Token: 0x02000005 RID: 5
	internal static class ApplicationAssistant
	{
		// Token: 0x06000017 RID: 23 RVA: 0x000024DC File Offset: 0x000006DC
		internal static Task GoToShutDown()
		{
			ApplicationAssistant.<GoToShutDown>d__0 <GoToShutDown>d__;
			<GoToShutDown>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<GoToShutDown>d__.<>1__state = -1;
			<GoToShutDown>d__.<>t__builder.Start<ApplicationAssistant.<GoToShutDown>d__0>(ref <GoToShutDown>d__);
			return <GoToShutDown>d__.<>t__builder.Task;
		}
	}
}
