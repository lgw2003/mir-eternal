using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 102, Length = 3, Description = "解锁铭文栏位")]
	public sealed class 解锁铭文栏位 : GamePacket
	{
		
		public 解锁铭文栏位()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 解锁参数;
	}
}
