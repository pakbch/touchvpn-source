using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using TouchVPN.ViewModel;
using Unity;

namespace TouchVPN
{
	// Token: 0x02000006 RID: 6
	public partial class TouchVpnShell : Window
	{
		// Token: 0x06000018 RID: 24 RVA: 0x00002517 File Offset: 0x00000717
		public TouchVpnShell()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000019 RID: 25 RVA: 0x00002525 File Offset: 0x00000725
		// (set) Token: 0x0600001A RID: 26 RVA: 0x00002532 File Offset: 0x00000732
		[Dependency]
		public ShellViewModel ShellViewModel
		{
			get
			{
				return base.DataContext as ShellViewModel;
			}
			set
			{
				base.DataContext = value;
			}
		}

		// Token: 0x0600001B RID: 27 RVA: 0x0000253B File Offset: 0x0000073B
		private void OnClosing(object sender, CancelEventArgs e)
		{
			base.Hide();
			e.Cancel = true;
		}
	}
}
