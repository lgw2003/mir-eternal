using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 24, Length = 0, Description = "同步称号信息")]
	public sealed class 同步称号信息 : GamePacket
	{
		
		public 同步称号信息()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 字节描述;
	}
}
