using System;
using System.Windows.Forms;
using GameServer.Properties;

namespace GameServer
{
	
	public sealed class SetUpExp : GMCommand
	{
		
		public override ExecutionWay ExecutionWay
		{
			get
			{
				return ExecutionWay.只能后台执行;
			}
		}

		
		public override void Execute()
		{
			if (this.经验倍率 <= 0m)
			{
				MainForm.添加命令日志("<= @" + base.GetType().Name + " Command execution failed, experience multiplier too low");
				return;
			}
			if (this.经验倍率 > 1000000m)
			{
				MainForm.添加命令日志("<= @" + base.GetType().Name + " Command execution failed, experience multiplier too high");
				return;
			}
			Settings.Default.ExpRate = (Config.怪物经验倍率 = this.经验倍率);
			Settings.Default.Save();
			MainForm.Singleton.BeginInvoke(new MethodInvoker(delegate()
			{
				MainForm.Singleton.S_ExpRate.Value = this.经验倍率;
			}));
			MainForm.添加命令日志(string.Format("<= @{0} The command has been executed, current experience multiplier: {1}", base.GetType().Name, Config.怪物经验倍率));
		}

		
		public SetUpExp()
		{
			
			
		}

		
		[FieldAttribute(0, Position = 0)]
		public decimal 经验倍率;
	}
}
