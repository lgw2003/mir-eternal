using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 22, Length = 6, Description = "进入传送门触发")]
	public sealed class 玩家进入法阵封包 : GamePacket
	{
		
		public 玩家进入法阵封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 法阵编号;
	}
}
