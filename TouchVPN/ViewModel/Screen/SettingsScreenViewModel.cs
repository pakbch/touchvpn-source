using System;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Mystique.Infrastructure.Startup;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace TouchVPN.ViewModel.Screen
{
	// Token: 0x0200000F RID: 15
	public class SettingsScreenViewModel : BindableBase, INavigationAware
	{
		// Token: 0x060000A1 RID: 161 RVA: 0x000038B7 File Offset: 0x00001AB7
		public SettingsScreenViewModel(IStartupProvider startupProvider)
		{
			this.startupProvider = startupProvider;
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060000A2 RID: 162 RVA: 0x000038C8 File Offset: 0x00001AC8
		public ICommand AddToStartupCommand
		{
			get
			{
				ICommand result;
				if ((result = this.addToStartupCommand) == null)
				{
					result = (this.addToStartupCommand = new DelegateCommand(delegate()
					{
						SettingsScreenViewModel.<<get_AddToStartupCommand>b__6_0>d <<get_AddToStartupCommand>b__6_0>d;
						<<get_AddToStartupCommand>b__6_0>d.<>t__builder = AsyncVoidMethodBuilder.Create();
						<<get_AddToStartupCommand>b__6_0>d.<>4__this = this;
						<<get_AddToStartupCommand>b__6_0>d.<>1__state = -1;
						<<get_AddToStartupCommand>b__6_0>d.<>t__builder.Start<SettingsScreenViewModel.<<get_AddToStartupCommand>b__6_0>d>(ref <<get_AddToStartupCommand>b__6_0>d);
					}));
				}
				return result;
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060000A3 RID: 163 RVA: 0x000038FC File Offset: 0x00001AFC
		public ICommand RemoveToStartupCommand
		{
			get
			{
				ICommand result;
				if ((result = this.removeFromStartupCommand) == null)
				{
					result = (this.removeFromStartupCommand = new DelegateCommand(delegate()
					{
						SettingsScreenViewModel.<<get_RemoveToStartupCommand>b__8_0>d <<get_RemoveToStartupCommand>b__8_0>d;
						<<get_RemoveToStartupCommand>b__8_0>d.<>t__builder = AsyncVoidMethodBuilder.Create();
						<<get_RemoveToStartupCommand>b__8_0>d.<>4__this = this;
						<<get_RemoveToStartupCommand>b__8_0>d.<>1__state = -1;
						<<get_RemoveToStartupCommand>b__8_0>d.<>t__builder.Start<SettingsScreenViewModel.<<get_RemoveToStartupCommand>b__8_0>d>(ref <<get_RemoveToStartupCommand>b__8_0>d);
					}));
				}
				return result;
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060000A4 RID: 164 RVA: 0x0000392D File Offset: 0x00001B2D
		// (set) Token: 0x060000A5 RID: 165 RVA: 0x00003935 File Offset: 0x00001B35
		public bool RunOnStartup
		{
			get
			{
				return this.runOnStartup;
			}
			set
			{
				this.SetProperty<bool>(ref this.runOnStartup, value, "RunOnStartup");
			}
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x0000394A File Offset: 0x00001B4A
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			this.RunOnStartup = this.startupProvider.ReadStartupSetting();
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x0000395D File Offset: 0x00001B5D
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00003960 File Offset: 0x00001B60
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
		}

		// Token: 0x04000051 RID: 81
		private readonly IStartupProvider startupProvider;

		// Token: 0x04000052 RID: 82
		private ICommand addToStartupCommand;

		// Token: 0x04000053 RID: 83
		private ICommand removeFromStartupCommand;

		// Token: 0x04000054 RID: 84
		private bool runOnStartup;
	}
}
