using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Microsoft.Web.WebView2.Wpf;
using Mystique.Infrastructure.ApplicationInfo;

namespace TouchVPN.PurchaseWindow
{
	// Token: 0x02000024 RID: 36
	public partial class CheckoutDialog : Window
	{
		// Token: 0x0600013F RID: 319 RVA: 0x00004C11 File Offset: 0x00002E11
		public CheckoutDialog()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00004C1F File Offset: 0x00002E1F
		public CheckoutDialog(Uri checkoutUri) : this()
		{
			this.InitWebView().ConfigureAwait(false);
			this.CheckoutPage.Source = checkoutUri;
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00004C40 File Offset: 0x00002E40
		public CheckoutDialog(Uri checkoutUri, ICommandLineArgsProvider commandLineArgsProvider) : this(checkoutUri)
		{
			this.commandLineArgsProvider = commandLineArgsProvider;
		}

		// Token: 0x06000142 RID: 322 RVA: 0x00004C50 File Offset: 0x00002E50
		private Task InitWebView()
		{
			CheckoutDialog.<InitWebView>d__4 <InitWebView>d__;
			<InitWebView>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<InitWebView>d__.<>4__this = this;
			<InitWebView>d__.<>1__state = -1;
			<InitWebView>d__.<>t__builder.Start<CheckoutDialog.<InitWebView>d__4>(ref <InitWebView>d__);
			return <InitWebView>d__.<>t__builder.Task;
		}

		// Token: 0x0400009B RID: 155
		private readonly ICommandLineArgsProvider commandLineArgsProvider;
	}
}
