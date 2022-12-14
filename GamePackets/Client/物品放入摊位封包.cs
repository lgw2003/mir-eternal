using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 107, Length = 11, Description = "物品放入摊位")]
	public sealed class 物品放入摊位封包 : GamePacket
	{
		
		public 物品放入摊位封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 放入位置;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 1)]
		public byte 物品容器;

		
		[WrappingFieldAttribute(SubScript = 4, Length = 1)]
		public byte 物品位置;

		
		[WrappingFieldAttribute(SubScript = 5, Length = 2)]
		public ushort 物品数量;

		
		[WrappingFieldAttribute(SubScript = 7, Length = 1)]
		public int 物品价格;
	}
}
