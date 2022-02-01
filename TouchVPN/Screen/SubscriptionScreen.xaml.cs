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
	// Token: 0x02000022 RID: 34
	public partial class SubscriptionScreen : UserControl
	{
		// Token: 0x06000134 RID: 308 RVA: 0x00004B4C File Offset: 0x00002D4C
		public SubscriptionScreen()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x06000135 RID: 309 RVA: 0x00004B5A File Offset: 0x00002D5A
		// (set) Token: 0x06000136 RID: 310 RVA: 0x00004B67 File Offset: 0x00002D67
		[Dependency]
		public SubscriptionScreenViewModel SubscriptionScreenViewModel
		{
			get
			{
				return base.DataContext as SubscriptionScreenViewModel;
			}
			set
			{
				base.DataContext = value;
			}
		}
	}
}
