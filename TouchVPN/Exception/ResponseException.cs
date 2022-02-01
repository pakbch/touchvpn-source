using System;
using System.Runtime.Serialization;
using Backend.UserApi.Model.Enums;

namespace TouchVPN.Exception
{
	// Token: 0x02000028 RID: 40
	[Serializable]
	public class ResponseException : Exception
	{
		// Token: 0x060001D4 RID: 468 RVA: 0x00005903 File Offset: 0x00003B03
		internal ResponseException()
		{
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x0000590B File Offset: 0x00003B0B
		internal ResponseException(string message) : base(message)
		{
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x00005914 File Offset: 0x00003B14
		internal ResponseException(ResponseResult result)
		{
			this.Result = result;
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x00005923 File Offset: 0x00003B23
		internal ResponseException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x0000592D File Offset: 0x00003B2D
		internal ResponseException(string message, ResponseResult result) : base(message)
		{
			this.Result = result;
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x0000593D File Offset: 0x00003B3D
		internal ResponseException(string message, Exception innerException, ResponseResult result) : base(message, innerException)
		{
			this.Result = result;
		}

		// Token: 0x060001DA RID: 474 RVA: 0x0000594E File Offset: 0x00003B4E
		internal ResponseException(Exception innerException, ResponseResult result) : this(string.Format("Firebase exception occured: {0}", result), innerException, result)
		{
		}

		// Token: 0x060001DB RID: 475 RVA: 0x00005968 File Offset: 0x00003B68
		protected ResponseException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x060001DC RID: 476 RVA: 0x00005972 File Offset: 0x00003B72
		public ResponseResult Result { get; }
	}
}
