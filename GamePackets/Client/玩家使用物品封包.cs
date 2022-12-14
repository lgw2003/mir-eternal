using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 45, Length = 4, Description = "玩家使用物品")]
	public sealed class 玩家使用物品封包 : GamePacket
	{
		
		public 玩家使用物品封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 背包类型;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 1)]
		public byte 物品位置;
	}
}
