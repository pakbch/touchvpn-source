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
	// Token: 0x0200001C RID: 28
	public partial class LoadingScreen : UserControl
	{
		// Token: 0x06000115 RID: 277 RVA: 0x000048F8 File Offset: 0x00002AF8
		public LoadingScreen()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000116 RID: 278 RVA: 0x00004906 File Offset: 0x00002B06
		// (set) Token: 0x06000117 RID: 279 RVA: 0x00004913 File Offset: 0x00002B13
		[Dependency]
		public LoadingScreenViewModel LoadingScreenViewModel
		{
			get
			{
				return base.DataContext as LoadingScreenViewModel;
			}
			set
			{
				base.DataContext = value;
			}
		}
	}
}
