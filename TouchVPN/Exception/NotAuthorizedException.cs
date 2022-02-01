using System;
using System.Runtime.Serialization;
using Backend.UserApi.Model.Enums;

namespace TouchVPN.Exception
{
	// Token: 0x02000027 RID: 39
	[Serializable]
	public class NotAuthorizedException : ResponseException
	{
		// Token: 0x060001CF RID: 463 RVA: 0x000058D5 File Offset: 0x00003AD5
		internal NotAuthorizedException()
		{
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x000058DD File Offset: 0x00003ADD
		internal NotAuthorizedException(string message) : base(message)
		{
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x000058E6 File Offset: 0x00003AE6
		internal NotAuthorizedException(ResponseResult result) : base(result)
		{
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x000058EF File Offset: 0x00003AEF
		internal NotAuthorizedException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x000058F9 File Offset: 0x00003AF9
		protected NotAuthorizedException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
