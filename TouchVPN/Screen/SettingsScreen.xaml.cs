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
	// Token: 0x02000020 RID: 32
	public partial class SettingsScreen : UserControl
	{
		// Token: 0x06000129 RID: 297 RVA: 0x00004A73 File Offset: 0x00002C73
		public SettingsScreen()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x0600012A RID: 298 RVA: 0x00004A81 File Offset: 0x00002C81
		// (set) Token: 0x0600012B RID: 299 RVA: 0x00004A8E File Offset: 0x00002C8E
		[Dependency]
		public SettingsScreenViewModel SettingsScreenViewModel
		{
			get
			{
				return base.DataContext as SettingsScreenViewModel;
			}
			set
			{
				base.DataContext = value;
			}
		}
	}
}
