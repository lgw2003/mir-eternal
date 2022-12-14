using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 73, Length = 4, Description = "替换高级铭文")]
	public sealed class 替换高级铭文封包 : GamePacket
	{
		
		public 替换高级铭文封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 装备类型;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 1)]
		public byte 装备位置;
	}
}
