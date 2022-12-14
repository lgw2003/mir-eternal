using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 70, Length = 8, Description = "普通铭文洗练")]
	public sealed class 普通铭文洗练封包 : GamePacket
	{
		
		public 普通铭文洗练封包()
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
