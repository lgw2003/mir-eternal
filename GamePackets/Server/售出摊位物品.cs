using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 163, Length = 11, Description = "售出摊位物品")]
	public sealed class 售出摊位物品 : GamePacket
	{
		
		public 售出摊位物品()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 物品位置;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 4)]
		public int 售出数量;

		
		[WrappingFieldAttribute(SubScript = 7, Length = 4)]
		public int 售出收益;
	}
}
