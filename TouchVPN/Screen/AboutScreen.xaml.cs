using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using TouchVPN.ViewModel.Screen;
using Unity;

namespace TouchVPN.Screen
{
	// Token: 0x02000018 RID: 24
	public partial class AboutScreen : UserControl
	{
		// Token: 0x060000FE RID: 254 RVA: 0x00004737 File Offset: 0x00002937
		public AboutScreen()
		{
			this.InitializeComponent();
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060000FF RID: 255 RVA: 0x00004745 File Offset: 0x00002945
		// (set) Token: 0x06000100 RID: 256 RVA: 0x00004752 File Offset: 0x00002952
		[Dependency]
		public AboutScreenViewModel AboutScreenViewModel
		{
			get
			{
				return base.DataContext as AboutScreenViewModel;
			}
			set
			{
				base.DataContext = value;
			}
		}
	}
}
