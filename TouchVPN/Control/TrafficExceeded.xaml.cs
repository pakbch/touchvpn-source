using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using TouchVPN.ViewModel.Control;
using Unity;

namespace TouchVPN.Control
{
	// Token: 0x0200002E RID: 46
	public partial class TrafficExceeded : UserControl
	{
		// Token: 0x06000219 RID: 537 RVA: 0x000062D8 File Offset: 0x000044D8
		public TrafficExceeded()
		{
			this.InitializeComponent();
		}

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x0600021A RID: 538 RVA: 0x000062E6 File Offset: 0x000044E6
		// (set) Token: 0x0600021B RID: 539 RVA: 0x000062F3 File Offset: 0x000044F3
		[Dependency]
		public TrafficExceededViewModel TrafficExceededViewModel
		{
			get
			{
				return base.DataContext as TrafficExceededViewModel;
			}
			set
			{
				base.DataContext = value;
			}
		}
	}
}
