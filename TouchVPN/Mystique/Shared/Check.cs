using System;

namespace Mystique.Shared
{
	// Token: 0x02000003 RID: 3
	internal class Check
	{
		// Token: 0x06000007 RID: 7 RVA: 0x000020C6 File Offset: 0x000002C6
		internal static void NotNull<T>(T value, string parameterName)
		{
			if (value == null)
			{
				throw new ArgumentNullException(parameterName);
			}
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000020D7 File Offset: 0x000002D7
		internal static void IsNullOrWhiteSpace(string value, string parameterName)
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				throw new ArgumentException(parameterName);
			}
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000020E8 File Offset: 0x000002E8
		internal static void IsNullOrEmpty(string value, string parameterName)
		{
			if (string.IsNullOrEmpty(value))
			{
				throw new ArgumentException(parameterName);
			}
		}
	}
}
