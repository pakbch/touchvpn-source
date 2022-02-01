using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace TouchVPN.Control
{
	// Token: 0x0200002A RID: 42
	public partial class ErrorDialog : UserControl
	{
		// Token: 0x060001E1 RID: 481 RVA: 0x000059FE File Offset: 0x00003BFE
		public ErrorDialog()
		{
			this.InitializeComponent();
			Panel.SetZIndex(this, int.MaxValue);
		}

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x060001E2 RID: 482 RVA: 0x00005A17 File Offset: 0x00003C17
		// (set) Token: 0x060001E3 RID: 483 RVA: 0x00005A29 File Offset: 0x00003C29
		public bool IsCancelButtonVisible
		{
			get
			{
				return (bool)base.GetValue(ErrorDialog.IsCancelButtonVisibleProperty);
			}
			set
			{
				base.SetValue(ErrorDialog.IsCancelButtonVisibleProperty, value);
			}
		}

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x060001E4 RID: 484 RVA: 0x00005A3C File Offset: 0x00003C3C
		// (set) Token: 0x060001E5 RID: 485 RVA: 0x00005A4E File Offset: 0x00003C4E
		public string OkButtonText
		{
			get
			{
				return (string)base.GetValue(ErrorDialog.OkButtonTextProperty);
			}
			set
			{
				base.SetValue(ErrorDialog.OkButtonTextProperty, value);
			}
		}

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x060001E6 RID: 486 RVA: 0x00005A5C File Offset: 0x00003C5C
		// (set) Token: 0x060001E7 RID: 487 RVA: 0x00005A6E File Offset: 0x00003C6E
		public string Title
		{
			get
			{
				return (string)base.GetValue(ErrorDialog.TitleProperty);
			}
			set
			{
				base.SetValue(ErrorDialog.TitleProperty, value);
			}
		}

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x060001E8 RID: 488 RVA: 0x00005A7C File Offset: 0x00003C7C
		// (set) Token: 0x060001E9 RID: 489 RVA: 0x00005A8E File Offset: 0x00003C8E
		public string Description
		{
			get
			{
				return (string)base.GetValue(ErrorDialog.DescriptionProperty);
			}
			set
			{
				base.SetValue(ErrorDialog.DescriptionProperty, value);
			}
		}

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x060001EA RID: 490 RVA: 0x00005A9C File Offset: 0x00003C9C
		// (set) Token: 0x060001EB RID: 491 RVA: 0x00005AAE File Offset: 0x00003CAE
		public ICommand CancelCommand
		{
			get
			{
				return (ICommand)base.GetValue(ErrorDialog.CancelCommandProperty);
			}
			set
			{
				base.SetValue(ErrorDialog.CancelCommandProperty, value);
			}
		}

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x060001EC RID: 492 RVA: 0x00005ABC File Offset: 0x00003CBC
		// (set) Token: 0x060001ED RID: 493 RVA: 0x00005ACE File Offset: 0x00003CCE
		public ICommand ContinueCommand
		{
			get
			{
				return (ICommand)base.GetValue(ErrorDialog.ContinueCommandProperty);
			}
			set
			{
				base.SetValue(ErrorDialog.ContinueCommandProperty, value);
			}
		}

		// Token: 0x040000A3 RID: 163
		public static readonly DependencyProperty IsCancelButtonVisibleProperty = DependencyProperty.Register("IsCancelButtonVisible", typeof(bool), typeof(ErrorDialog));

		// Token: 0x040000A4 RID: 164
		public static readonly DependencyProperty OkButtonTextProperty = DependencyProperty.Register("OkButtonText", typeof(string), typeof(ErrorDialog));

		// Token: 0x040000A5 RID: 165
		public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(ErrorDialog));

		// Token: 0x040000A6 RID: 166
		public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register("Description", typeof(string), typeof(ErrorDialog));

		// Token: 0x040000A7 RID: 167
		public static readonly DependencyProperty CancelCommandProperty = DependencyProperty.Register("CancelCommand", typeof(ICommand), typeof(ErrorDialog));

		// Token: 0x040000A8 RID: 168
		public static readonly DependencyProperty ContinueCommandProperty = DependencyProperty.Register("ContinueCommand", typeof(ICommand), typeof(ErrorDialog));
	}
}
