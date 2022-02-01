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
	// Token: 0x0200001A RID: 26
	public partial class DebugScreen : UserControl
	{
		// Token: 0x0600010A RID: 266 RVA: 0x0000481E File Offset: 0x00002A1E
		public DebugScreen()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x0600010B RID: 267 RVA: 0x0000482C File Offset: 0x00002A2C
		// (set) Token: 0x0600010C RID: 268 RVA: 0x00004839 File Offset: 0x00002A39
		[Dependency]
		public DebugScreenViewModel DebugScreenViewModel
		{
			get
			{
				return base.DataContext as DebugScreenViewModel;
			}
			set
			{
				base.DataContext = value;
			}
		}
	}
}
