using System;
using GameServer.Data;
using GameServer.Networking;

namespace GameServer
{
	
	public sealed class AddIngots : GMCommand
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
					CharacterData.元宝数量 += this.Ingots;
					客户网络 网络连接 = CharacterData.网络连接;
					if (网络连接 != null)
					{
						网络连接.发送封包(new 同步元宝数量
						{
							Ingots = CharacterData.元宝数量
						});
					}
					MainForm.添加命令日志(string.Format("<= @{0} command has been executed, current amount of treasure: {1}", base.GetType().Name, CharacterData.元宝数量));
					return;
				}
			}
			MainForm.添加命令日志("<= @" + base.GetType().Name + " Command execution failed, role does not exist");
		}

		
		public AddIngots()
		{
			
			
		}

		
		[FieldAttribute(0, Position = 0)]
		public string CharName;

		
		[FieldAttribute(0, Position = 1)]
		public int Ingots;
	}
}
