using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 548, Length = 7, Description = "同步师徒等级")]
	public sealed class 同步师徒等级 : GamePacket
	{
		
		public 同步师徒等级()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 1)]
		public byte 对象等级;
	}
}
