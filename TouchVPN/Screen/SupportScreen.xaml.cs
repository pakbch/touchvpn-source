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
	// Token: 0x02000023 RID: 35
	public partial class SupportScreen : UserControl
	{
		// Token: 0x0600013A RID: 314 RVA: 0x00004BB3 File Offset: 0x00002DB3
		public SupportScreen()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x0600013B RID: 315 RVA: 0x00004BC1 File Offset: 0x00002DC1
		// (set) Token: 0x0600013C RID: 316 RVA: 0x00004BCE File Offset: 0x00002DCE
		[Dependency]
		public SupportScreenViewModel SupportScreenViewModel
		{
			get
			{
				return base.DataContext as SupportScreenViewModel;
			}
			set
			{
				base.DataContext = value;
			}
		}
	}
}
