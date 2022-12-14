using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 52, Length = 3, Description = "CharacterRepurchageItemsPacket")]
	public sealed class 玩家回购物品封包 : GamePacket
	{
		
		public 玩家回购物品封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 物品位置;
	}
}
