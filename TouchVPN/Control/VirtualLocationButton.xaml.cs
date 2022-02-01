using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace TouchVPN.Control
{
	// Token: 0x02000030 RID: 48
	public partial class VirtualLocationButton : Button
	{
		// Token: 0x06000224 RID: 548 RVA: 0x0000639F File Offset: 0x0000459F
		public VirtualLocationButton()
		{
			this.InitializeComponent();
		}

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x06000225 RID: 549 RVA: 0x000063AD File Offset: 0x000045AD
		// (set) Token: 0x06000226 RID: 550 RVA: 0x000063BF File Offset: 0x000045BF
		public ImageSource VirtualLocationImageSource
		{
			get
			{
				return (ImageSource)base.GetValue(VirtualLocationButton.VirtualLocationImageSourceProperty);
			}
			set
			{
				base.SetValue(VirtualLocationButton.VirtualLocationImageSourceProperty, value);
			}
		}

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x06000227 RID: 551 RVA: 0x000063CD File Offset: 0x000045CD
		// (set) Token: 0x06000228 RID: 552 RVA: 0x000063DF File Offset: 0x000045DF
		public ImageSource ArrowImageSource
		{
			get
			{
				return (ImageSource)base.GetValue(VirtualLocationButton.ArrowImageSourceProperty);
			}
			set
			{
				base.SetValue(VirtualLocationButton.ArrowImageSourceProperty, value);
			}
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x06000229 RID: 553 RVA: 0x000063ED File Offset: 0x000045ED
		// (set) Token: 0x0600022A RID: 554 RVA: 0x000063FF File Offset: 0x000045FF
		public string VirtualLocationName
		{
			get
			{
				return (string)base.GetValue(VirtualLocationButton.VirtualLocationNameProperty);
			}
			set
			{
				base.SetValue(VirtualLocationButton.VirtualLocationNameProperty, value);
			}
		}

		// Token: 0x040000C1 RID: 193
		public static readonly DependencyProperty VirtualLocationImageSourceProperty = DependencyProperty.Register("VirtualLocationImageSource", typeof(ImageSource), typeof(VirtualLocationButton));

		// Token: 0x040000C2 RID: 194
		public static readonly DependencyProperty ArrowImageSourceProperty = DependencyProperty.Register("ArrowImageSource", typeof(ImageSource), typeof(VirtualLocationButton));

		// Token: 0x040000C3 RID: 195
		public static readonly DependencyProperty VirtualLocationNameProperty = DependencyProperty.Register("VirtualLocationName", typeof(string), typeof(VirtualLocationButton));
	}
}
