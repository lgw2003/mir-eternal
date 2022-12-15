using System;
using System.Windows.Forms;
using GameServer.Properties;

namespace GameServer
{
	
	public sealed class OpenLevel : GMCommand
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
			if (this.最高等级 <= Config.游戏开放等级)
			{
				MainForm.添加命令日志("<= @" + base.GetType().Name + " Command execution failed, the level is lower than the current OpenLevelCommand");
				return;
			}
			Settings.Default.MaxLevel = (Config.游戏开放等级 = this.最高等级);
			Settings.Default.Save();
			MainForm.Singleton.BeginInvoke(new MethodInvoker(delegate()
			{
				MainForm.Singleton.S_MaxLevel.Value = this.最高等级;
			}));
			MainForm.添加命令日志(string.Format("<= @{0} The command has been executed, the current OpenLevelCommand: {1}", base.GetType().Name, Config.游戏开放等级));
		}

		
		public OpenLevel()
		{
			
			
		}

		
		[FieldAttribute(0, Position = 0)]
		public byte 最高等级;
	}
}
