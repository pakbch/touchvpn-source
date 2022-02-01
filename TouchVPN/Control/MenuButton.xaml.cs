using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;

namespace TouchVPN.Control
{
	// Token: 0x0200002D RID: 45
	public partial class MenuButton : RadioButton
	{
		// Token: 0x06000201 RID: 513 RVA: 0x00005F61 File Offset: 0x00004161
		public MenuButton()
		{
			this.InitializeComponent();
		}

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x06000202 RID: 514 RVA: 0x00005F6F File Offset: 0x0000416F
		// (set) Token: 0x06000203 RID: 515 RVA: 0x00005F81 File Offset: 0x00004181
		public string Text
		{
			get
			{
				return (string)base.GetValue(MenuButton.TextProperty);
			}
			set
			{
				base.SetValue(MenuButton.TextProperty, value);
			}
		}

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x06000204 RID: 516 RVA: 0x00005F8F File Offset: 0x0000418F
		// (set) Token: 0x06000205 RID: 517 RVA: 0x00005FA1 File Offset: 0x000041A1
		public ImageSource ImageSource
		{
			get
			{
				return (ImageSource)base.GetValue(MenuButton.ImageSourceProperty);
			}
			set
			{
				base.SetValue(MenuButton.ImageSourceProperty, value);
			}
		}

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x06000206 RID: 518 RVA: 0x00005FAF File Offset: 0x000041AF
		// (set) Token: 0x06000207 RID: 519 RVA: 0x00005FC1 File Offset: 0x000041C1
		public double ImageWidth
		{
			get
			{
				return (double)base.GetValue(MenuButton.ImageWidthProperty);
			}
			set
			{
				base.SetValue(MenuButton.ImageWidthProperty, value);
			}
		}

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x06000208 RID: 520 RVA: 0x00005FD4 File Offset: 0x000041D4
		// (set) Token: 0x06000209 RID: 521 RVA: 0x00005FE6 File Offset: 0x000041E6
		public double ImageHeight
		{
			get
			{
				return (double)base.GetValue(MenuButton.ImageHeightProperty);
			}
			set
			{
				base.SetValue(MenuButton.ImageHeightProperty, value);
			}
		}

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x0600020A RID: 522 RVA: 0x00005FF9 File Offset: 0x000041F9
		// (set) Token: 0x0600020B RID: 523 RVA: 0x0000600B File Offset: 0x0000420B
		[TypeConverter(typeof(BrushConverter))]
		public Brush CheckedContentBrush
		{
			get
			{
				return (Brush)base.GetValue(MenuButton.CheckedContentBrushProperty);
			}
			set
			{
				base.SetValue(MenuButton.CheckedContentBrushProperty, value);
			}
		}

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x0600020C RID: 524 RVA: 0x00006019 File Offset: 0x00004219
		// (set) Token: 0x0600020D RID: 525 RVA: 0x0000602B File Offset: 0x0000422B
		[TypeConverter(typeof(BrushConverter))]
		public Brush UnCheckedContentBrush
		{
			get
			{
				return (Brush)base.GetValue(MenuButton.UnCheckedContentBrushProperty);
			}
			set
			{
				base.SetValue(MenuButton.UnCheckedContentBrushProperty, value);
			}
		}

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x0600020E RID: 526 RVA: 0x00006039 File Offset: 0x00004239
		// (set) Token: 0x0600020F RID: 527 RVA: 0x0000604B File Offset: 0x0000424B
		[TypeConverter(typeof(BrushConverter))]
		public Brush ImageBrush
		{
			get
			{
				return (Brush)base.GetValue(MenuButton.ImageBrushProperty);
			}
			set
			{
				base.SetValue(MenuButton.ImageBrushProperty, value);
			}
		}

		// Token: 0x06000210 RID: 528 RVA: 0x00006059 File Offset: 0x00004259
		private static void PropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
		{
			((MenuButton)dependencyObject).CheckedContentBrushChanged((Brush)dependencyPropertyChangedEventArgs.NewValue);
		}

		// Token: 0x06000211 RID: 529 RVA: 0x00006072 File Offset: 0x00004272
		private void RadioButtonChecked(object sender, RoutedEventArgs e)
		{
			this.ImageBrush = this.CheckedContentBrush;
		}

		// Token: 0x06000212 RID: 530 RVA: 0x00006080 File Offset: 0x00004280
		private void RadioButtonUnChecked(object sender, RoutedEventArgs e)
		{
			this.ImageBrush = this.UnCheckedContentBrush;
		}

		// Token: 0x06000213 RID: 531 RVA: 0x00006090 File Offset: 0x00004290
		private void CheckedContentBrushChanged(Brush newValue)
		{
			if (base.IsChecked != null && base.IsChecked.Value)
			{
				this.ImageBrush = newValue;
			}
		}

		// Token: 0x06000214 RID: 532 RVA: 0x000060C4 File Offset: 0x000042C4
		private void OnMouseEnter(object sender, MouseEventArgs e)
		{
			this.ImageBrush = this.CheckedContentBrush;
		}

		// Token: 0x06000215 RID: 533 RVA: 0x000060D4 File Offset: 0x000042D4
		private void OnMouseLeave(object sender, MouseEventArgs e)
		{
			if (base.IsChecked == null || base.IsChecked.Value)
			{
				return;
			}
			this.ImageBrush = this.UnCheckedContentBrush;
		}

		// Token: 0x040000B6 RID: 182
		public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(MenuButton));

		// Token: 0x040000B7 RID: 183
		public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(MenuButton));

		// Token: 0x040000B8 RID: 184
		public static readonly DependencyProperty ImageWidthProperty = DependencyProperty.Register("ImageWidth", typeof(double), typeof(MenuButton));

		// Token: 0x040000B9 RID: 185
		public static readonly DependencyProperty ImageHeightProperty = DependencyProperty.Register("ImageHeight", typeof(double), typeof(MenuButton));

		// Token: 0x040000BA RID: 186
		public static readonly DependencyProperty CheckedContentBrushProperty = DependencyProperty.Register("CheckedContentBrush", typeof(Brush), typeof(MenuButton), new PropertyMetadata(null, new PropertyChangedCallback(MenuButton.PropertyChangedCallback)));

		// Token: 0x040000BB RID: 187
		public static readonly DependencyProperty UnCheckedContentBrushProperty = DependencyProperty.Register("UnCheckedContentBrush", typeof(Brush), typeof(MenuButton));

		// Token: 0x040000BC RID: 188
		public static readonly DependencyProperty ImageBrushProperty = DependencyProperty.Register("ImageBrush", typeof(Brush), typeof(MenuButton));
	}
}
