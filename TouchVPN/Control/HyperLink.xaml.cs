using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Navigation;

namespace TouchVPN.Control
{
	// Token: 0x0200002B RID: 43
	public partial class HyperLink : TextBlock
	{
		// Token: 0x060001F1 RID: 497 RVA: 0x00005C07 File Offset: 0x00003E07
		public HyperLink()
		{
			this.InitializeComponent();
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x060001F2 RID: 498 RVA: 0x00005C15 File Offset: 0x00003E15
		// (set) Token: 0x060001F3 RID: 499 RVA: 0x00005C27 File Offset: 0x00003E27
		public string NavigateAddress
		{
			get
			{
				return (string)base.GetValue(HyperLink.NavigateAddressProperty);
			}
			set
			{
				base.SetValue(HyperLink.NavigateAddressProperty, value);
			}
		}

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x060001F4 RID: 500 RVA: 0x00005C35 File Offset: 0x00003E35
		// (set) Token: 0x060001F5 RID: 501 RVA: 0x00005C47 File Offset: 0x00003E47
		public string LinkText
		{
			get
			{
				return (string)base.GetValue(HyperLink.LinkTextProperty);
			}
			set
			{
				base.SetValue(HyperLink.LinkTextProperty, value);
			}
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x00005C55 File Offset: 0x00003E55
		private void HyperlinkOnRequestNavigate(object sender, RequestNavigateEventArgs e)
		{
			Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
			e.Handled = true;
		}

		// Token: 0x040000AB RID: 171
		public static readonly DependencyProperty NavigateAddressProperty = DependencyProperty.Register("NavigateAddress", typeof(string), typeof(HyperLink));

		// Token: 0x040000AC RID: 172
		public static readonly DependencyProperty LinkTextProperty = DependencyProperty.Register("LinkText", typeof(string), typeof(HyperLink));
	}
}
