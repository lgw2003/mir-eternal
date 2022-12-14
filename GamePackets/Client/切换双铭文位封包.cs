using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 75, Length = 5, Description = "ToggleDoubleInscriptionBitPacket")]
	public sealed class 切换双铭文位封包 : GamePacket
	{
		
		public 切换双铭文位封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 装备类型;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 1)]
		public byte 装备位置;

		
		[WrappingFieldAttribute(SubScript = 4, Length = 1)]
		public byte 操作参数;
	}
}
