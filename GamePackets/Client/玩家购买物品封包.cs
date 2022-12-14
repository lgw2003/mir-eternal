using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 49, Length = 12, Description = "CharacterPurchageItemsPacket")]
	public sealed class 玩家购买物品封包 : GamePacket
	{
		
		public 玩家购买物品封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 商店编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 6)]
		public int 物品位置;

		
		[WrappingFieldAttribute(SubScript = 10, Length = 2)]
		public ushort 购入数量;
	}
}
