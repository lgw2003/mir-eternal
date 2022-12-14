using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 68, Length = 0, Description = "同步黑名单表")]
	public sealed class 同步黑名单表 : GamePacket
	{
		
		public 同步黑名单表()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 字节描述;
	}
}
