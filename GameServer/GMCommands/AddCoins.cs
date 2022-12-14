using System;
using GameServer.Data;
using GameServer.Networking;

namespace GameServer
{
	
	public sealed class AddCoins : GMCommand
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
					CharacterData.NumberGoldCoins += this.NumberGoldCoins;
					客户网络 网络连接 = CharacterData.ActiveConnection;
					if (网络连接 != null)
					{
						网络连接.发送封包(new 货币数量变动
						{
							货币类型 = 1,
							货币数量 = CharacterData.NumberGoldCoins
						});
					}
					MainForm.AddCommandLog(string.Format("<= @{0} command has been executed, current coin count: {1}", base.GetType().Name, CharacterData.NumberGoldCoins));
					return;
				}
			}
			MainForm.AddCommandLog("<= @" + base.GetType().Name + " Command execution failed, role does not exist");
		}

		
		public AddCoins()
		{
			
			
		}

		
		[FieldAttribute(0, Position = 0)]
		public string CharName;

		
		[FieldAttribute(0, Position = 1)]
		public int NumberGoldCoins;
	}
}
