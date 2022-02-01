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
	// Token: 0x02000021 RID: 33
	public partial class SignInScreen : UserControl
	{
		// Token: 0x0600012E RID: 302 RVA: 0x00004AD1 File Offset: 0x00002CD1
		public SignInScreen()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x0600012F RID: 303 RVA: 0x00004ADF File Offset: 0x00002CDF
		// (set) Token: 0x06000130 RID: 304 RVA: 0x00004AEC File Offset: 0x00002CEC
		[Dependency]
		public SignInScreenViewModel SignInScreenViewModel
		{
			get
			{
				return base.DataContext as SignInScreenViewModel;
			}
			set
			{
				base.DataContext = value;
			}
		}
	}
}
