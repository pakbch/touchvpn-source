using System;

namespace TouchVPN.Event
{
	// Token: 0x02000029 RID: 41
	internal class SubscriptionWatchdog
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x060001DD RID: 477 RVA: 0x0000597C File Offset: 0x00003B7C
		// (remove) Token: 0x060001DE RID: 478 RVA: 0x000059B0 File Offset: 0x00003BB0
		internal static event EventHandler<bool> Owned;

		// Token: 0x060001DF RID: 479 RVA: 0x000059E3 File Offset: 0x00003BE3
		internal static void MakeOwn(bool willBeOwned)
		{
			EventHandler<bool> owned = SubscriptionWatchdog.Owned;
			if (owned == null)
			{
				return;
			}
			owned(null, willBeOwned);
		}
	}
}
