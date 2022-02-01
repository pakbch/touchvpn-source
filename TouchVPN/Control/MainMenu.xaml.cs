using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Mystique.Navigation;
using TouchVPN.ViewModel.Control;
using Unity;

namespace TouchVPN.Control
{
	// Token: 0x0200002C RID: 44
	public partial class MainMenu : UserControl
	{
		// Token: 0x060001FA RID: 506 RVA: 0x00005D1F File Offset: 0x00003F1F
		public MainMenu()
		{
			this.InitializeComponent();
			NavigationWatchdog.Woof += this.SelectButtonOnWoof;
		}

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x060001FB RID: 507 RVA: 0x00005D3E File Offset: 0x00003F3E
		// (set) Token: 0x060001FC RID: 508 RVA: 0x00005D4B File Offset: 0x00003F4B
		[Dependency]
		public MainMenuViewModel MainMenuViewModel
		{
			get
			{
				return base.DataContext as MainMenuViewModel;
			}
			set
			{
				base.DataContext = value;
			}
		}

		// Token: 0x060001FD RID: 509 RVA: 0x00005D54 File Offset: 0x00003F54
		private void SelectButtonOnWoof(object sender, WatchdogEventArgs e)
		{
			string name = e.TargetScreen.Name;
			uint num = <PrivateImplementationDetails>.ComputeStringHash(name);
			if (num > 2630636024U)
			{
				if (num <= 3306974087U)
				{
					if (num != 3024400828U)
					{
						if (num != 3306974087U)
						{
							return;
						}
						if (!(name == "SignInScreen"))
						{
							return;
						}
						goto IL_D4;
					}
					else
					{
						if (!(name == "SupportScreen"))
						{
							return;
						}
						this.SupportScreenButton.IsChecked = new bool?(true);
					}
				}
				else if (num != 3492424512U)
				{
					if (num == 3946457506U)
					{
						if (!(name == "HomeScreen"))
						{
							return;
						}
						this.HomeScreenButton.IsChecked = new bool?(true);
						return;
					}
				}
				else
				{
					if (!(name == "SubscriptionScreen"))
					{
						return;
					}
					this.SubscriptionScreenButton.IsChecked = new bool?(true);
					return;
				}
				return;
			}
			if (num != 1478089234U)
			{
				if (num != 2211764764U)
				{
					if (num != 2630636024U)
					{
						return;
					}
					if (!(name == "AccountScreen"))
					{
						return;
					}
				}
				else
				{
					if (!(name == "SettingsScreen"))
					{
						return;
					}
					this.SettingsScreenButton.IsChecked = new bool?(true);
					return;
				}
			}
			else
			{
				if (!(name == "AboutScreen"))
				{
					return;
				}
				this.AboutScreenButton.IsChecked = new bool?(true);
				return;
			}
			IL_D4:
			this.AccountScreenButton.IsChecked = new bool?(true);
		}
	}
}
