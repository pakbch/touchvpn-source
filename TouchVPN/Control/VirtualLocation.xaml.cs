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
	// Token: 0x0200002F RID: 47
	public partial class VirtualLocation : UserControl
	{
		// Token: 0x0600021E RID: 542 RVA: 0x00006335 File Offset: 0x00004535
		public VirtualLocation()
		{
			this.InitializeComponent();
		}

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x0600021F RID: 543 RVA: 0x00006343 File Offset: 0x00004543
		// (set) Token: 0x06000220 RID: 544 RVA: 0x00006350 File Offset: 0x00004550
		[Dependency]
		public VirtualLocationViewModel VirtualLocationViewModel
		{
			get
			{
				return base.DataContext as VirtualLocationViewModel;
			}
			set
			{
				base.DataContext = value;
			}
		}
	}
}
