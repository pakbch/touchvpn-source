using System;
using Backend.UserApi.Model.Enums;
using Backend.UserApi.Responses;
using TouchVPN.Exception;

namespace TouchVPN.Extension
{
	// Token: 0x02000026 RID: 38
	internal static class BaseResponseExtensions
	{
		// Token: 0x060001CE RID: 462 RVA: 0x0000589C File Offset: 0x00003A9C
		internal static void CheckSuccess(this BaseResponse response)
		{
			ResponseResult result = response.Result;
			if (result != ResponseResult.Ok)
			{
				if (result == ResponseResult.NotAuthorized)
				{
					throw new NotAuthorizedException(response.Result);
				}
				if (result != ResponseResult.Unlimited)
				{
					throw new ResponseException(response.Result);
				}
			}
		}
	}
}
