﻿using System;
using System.Text;
using GameServer.Data;

namespace GameServer
{
	
	public sealed class RenameCharacter : GMCommand
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
			if (GameDataGateway.角色数据表.Keyword.TryGetValue(this.CurrentCharacterName, out GameData))
			{
				CharacterData CharacterData = GameData as CharacterData;
				if (CharacterData != null)
				{
					if (CharacterData.网络连接 != null || CharacterData.所属账号.V.网络连接 != null)
					{
						MainForm.添加命令日志("<= @" + base.GetType().Name + " Command execution failed, account must be taken offline");
						return;
					}
					if (Encoding.UTF8.GetBytes(this.NewCharacterName).Length > 24)
					{
						MainForm.添加命令日志("<= @" + base.GetType().Name + " Command execution failed, character name too long");
						return;
					}
					if (GameDataGateway.角色数据表.Keyword.ContainsKey(this.NewCharacterName))
					{
						MainForm.添加命令日志("<= @" + base.GetType().Name + " Command execution failed, name already registered");
						return;
					}
					GameDataGateway.角色数据表.Keyword.Remove(CharacterData.角色名字.V);
					CharacterData.角色名字.V = this.NewCharacterName;
					GameDataGateway.角色数据表.Keyword.Add(CharacterData.角色名字.V, CharacterData);
					MainForm.添加命令日志(string.Format("<= @{0} command has been executed, with the current name of the character: {1}", base.GetType().Name, CharacterData));
					return;
				}
			}
			MainForm.添加命令日志("<= @" + base.GetType().Name + " Command execution failed, role does not exist");
		}

		
		public RenameCharacter()
		{
		}

		
		[FieldAttribute(0, Position = 0)]
		public string CurrentCharacterName;

		
		[FieldAttribute(0, Position = 1)]
		public string NewCharacterName;
	}
}
