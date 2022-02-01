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
	// Token: 0x0200001E RID: 30
	public partial class PasswordResetScreen : UserControl
	{
		// Token: 0x0600011E RID: 286 RVA: 0x000049A9 File Offset: 0x00002BA9
		public PasswordResetScreen()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x0600011F RID: 287 RVA: 0x000049B7 File Offset: 0x00002BB7
		// (set) Token: 0x06000120 RID: 288 RVA: 0x000049C4 File Offset: 0x00002BC4
		[Dependency]
		public PasswordResetScreenViewModel PasswordResetScreenViewModel
		{
			get
			{
				return base.DataContext as PasswordResetScreenViewModel;
			}
			set
			{
				base.DataContext = value;
			}
		}
	}
}
