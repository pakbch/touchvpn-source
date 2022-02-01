using System;
using System.IO;

namespace TouchVPN.Constant
{
	// Token: 0x02000031 RID: 49
	internal static class AnimationFileNames
	{
		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x0600022E RID: 558 RVA: 0x000064C2 File Offset: 0x000046C2
		public static string ProcessingAnimationFileName
		{
			get
			{
				return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Asset\\ConnectButtonAnimation", "Loader.json");
			}
		}

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x0600022F RID: 559 RVA: 0x000064DD File Offset: 0x000046DD
		public static string SwitchedOffAnimationFileName
		{
			get
			{
				return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Asset\\ConnectButtonAnimation", "Disconnected.json");
			}
		}

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x06000230 RID: 560 RVA: 0x000064F8 File Offset: 0x000046F8
		public static string SwitchedOffButtonClickAnimationFileName
		{
			get
			{
				return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Asset\\ConnectButtonAnimation", "ToConnect.json");
			}
		}

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x06000231 RID: 561 RVA: 0x00006513 File Offset: 0x00004713
		public static string SwitchedOnAnimationFileName
		{
			get
			{
				return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Asset\\ConnectButtonAnimation", "Connected.json");
			}
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x06000232 RID: 562 RVA: 0x0000652E File Offset: 0x0000472E
		public static string SwitchedOnButtonClickAnimationFileName
		{
			get
			{
				return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Asset\\ConnectButtonAnimation", "ToDisconnect.json");
			}
		}

		// Token: 0x040000C5 RID: 197
		private const string AnimationFilePath = "Asset\\ConnectButtonAnimation";
	}
}
