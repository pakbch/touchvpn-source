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
	// Token: 0x0200001F RID: 31
	public partial class PersonalDataAgreementScreen : UserControl
	{
		// Token: 0x06000123 RID: 291 RVA: 0x00004A09 File Offset: 0x00002C09
		public PersonalDataAgreementScreen()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x06000124 RID: 292 RVA: 0x00004A17 File Offset: 0x00002C17
		// (set) Token: 0x06000125 RID: 293 RVA: 0x00004A24 File Offset: 0x00002C24
		[Dependency]
		public PersonalDataAgreementScreenViewModel PersonalDataAgreementScreenViewModel
		{
			get
			{
				return base.DataContext as PersonalDataAgreementScreenViewModel;
			}
			set
			{
				base.DataContext = value;
			}
		}
	}
}
