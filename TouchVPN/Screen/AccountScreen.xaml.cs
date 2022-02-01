using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using TouchVPN.ViewModel.Screen;
using Unity;

namespace TouchVPN.Screen
{
	// Token: 0x02000019 RID: 25
	public partial class AccountScreen : UserControl
	{
		// Token: 0x06000104 RID: 260 RVA: 0x0000479F File Offset: 0x0000299F
		public AccountScreen()
		{
			this.InitializeComponent();
			base.Focusable = true;
			base.Loaded += delegate(object s, RoutedEventArgs e)
			{
				Keyboard.Focus(this);
			};
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x06000105 RID: 261 RVA: 0x000047C6 File Offset: 0x000029C6
		// (set) Token: 0x06000106 RID: 262 RVA: 0x000047D3 File Offset: 0x000029D3
		[Dependency]
		public AccountScreenViewModel AccountScreenViewModel
		{
			get
			{
				return base.DataContext as AccountScreenViewModel;
			}
			set
			{
				base.DataContext = value;
			}
		}
	}
}
