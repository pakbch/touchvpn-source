using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Mystique.UI.ConnectButton;
using TouchVPN.ViewModel.Screen;
using Unity;

namespace TouchVPN.Screen
{
	// Token: 0x0200001B RID: 27
	public partial class HomeScreen : UserControl
	{
		// Token: 0x0600010F RID: 271 RVA: 0x0000487D File Offset: 0x00002A7D
		public HomeScreen()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000110 RID: 272 RVA: 0x0000488B File Offset: 0x00002A8B
		// (set) Token: 0x06000111 RID: 273 RVA: 0x00004898 File Offset: 0x00002A98
		[Dependency]
		public HomeScreenViewModel HomeScreenViewModel
		{
			get
			{
				return base.DataContext as HomeScreenViewModel;
			}
			set
			{
				base.DataContext = value;
			}
		}
	}
}
