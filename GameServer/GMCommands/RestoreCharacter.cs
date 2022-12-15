using System;
using GameServer.Data;

namespace GameServer
{
	
	public sealed class RestoreCharacter : GMCommand
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
			if (GameDataGateway.角色数据表.Keyword.TryGetValue(this.CharacterName, out GameData))
			{
				CharacterData CharacterData = GameData as CharacterData;
				if (CharacterData != null)
				{
					if (CharacterData.删除日期.V == default(DateTime) || !CharacterData.所属账号.V.删除列表.Contains(CharacterData))
					{
						MainForm.添加命令日志("<= @" + base.GetType().Name + " Command execution failed, character not deleted");
						return;
					}
					if (CharacterData.所属账号.V.角色列表.Count >= 4)
					{
						MainForm.添加命令日志("<= @" + base.GetType().Name + " Command execution failed, character list is full");
						return;
					}
					if (CharacterData.所属账号.V.网络连接 != null)
					{
						MainForm.添加命令日志("<= @" + base.GetType().Name + " Command execution failed, account must be offline");
						return;
					}
					CharacterData.冻结日期.V = default(DateTime);
					CharacterData.删除日期.V = default(DateTime);
					CharacterData.所属账号.V.删除列表.Remove(CharacterData);
					CharacterData.所属账号.V.角色列表.Add(CharacterData);
					MainForm.添加命令日志("<= @" + base.GetType().Name + " Command executed, character restored successfully");
					return;
				}
			}
			MainForm.添加命令日志("<= @" + base.GetType().Name + " Command execution failed, character does not exist");
		}

		
		public RestoreCharacter()
		{
			
			
		}

		
		[FieldAttribute(0, Position = 0)]
		public string CharacterName;
	}
}
