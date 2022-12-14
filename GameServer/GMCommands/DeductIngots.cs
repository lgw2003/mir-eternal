using System;
using GameServer.Data;
using GameServer.Networking;

namespace GameServer
{
	
	public sealed class DeductIngots : GMCommand
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
					CharacterData.Ingots = Math.Max(0, CharacterData.Ingots - this.Ingots);
					客户网络 网络连接 = CharacterData.ActiveConnection;
					if (网络连接 != null)
					{
						网络连接.发送封包(new 同步元宝数量
						{
							Ingots = CharacterData.Ingots
						});
					}
					MainForm.AddCommandLog(string.Format("<= @{0} command has been executed, with the current amount of treasure: {1}", base.GetType().Name, CharacterData.Ingots));
					return;
				}
			}
			MainForm.AddCommandLog("<= @" + base.GetType().Name + " Command execution failed, role does not exist");
		}

		
		public DeductIngots()
		{
			
			
		}

		
		[FieldAttribute(0, Position = 0)]
		public string CharName;

		
		[FieldAttribute(0, Position = 1)]
		public int Ingots;
	}
}
