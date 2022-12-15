using System;
using GameServer.Data;

namespace GameServer
{
	
	public sealed class UnblockCharacter : GMCommand
	{
		
		public override ExecutionWay ExecutionWay
		{
			get
			{
				return ExecutionWay.优先后台执行;
			}
		}

		
		public override void Execute()
		{
			GameData GameData;
			if (GameDataGateway.角色数据表.Keyword.TryGetValue(this.CharName, out GameData))
			{
				CharacterData CharacterData = GameData as CharacterData;
				if (CharacterData != null)
				{
					CharacterData.封禁日期.V = default(DateTime);
					MainForm.添加命令日志(string.Format("<= @{0} Command executed, blocking expiry time: {1}", base.GetType().Name, CharacterData.封禁日期));
					return;
				}
			}
			MainForm.添加命令日志("<= @" + base.GetType().Name + " Command execution failed, character does not exist");
		}

		
		public UnblockCharacter()
		{
			
			
		}

		
		[FieldAttribute(0, Position = 0)]
		public string CharName;
	}
}
