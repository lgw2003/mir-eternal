using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 78, Length = 11, Description = "放弃铭文替换")]
	public sealed class 放弃铭文替换封包 : GamePacket
	{
		
		public 放弃铭文替换封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 装备类型;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 1)]
		public byte 装备位置;

		
		[WrappingFieldAttribute(SubScript = 4, Length = 4)]
		public int Id;
	}
}
