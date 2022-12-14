using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 641, Length = 258, Description = "行会外交公告")]
	public sealed class 行会外交公告 : GamePacket
	{
		
		public 行会外交公告()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 256)]
		public byte[] 字节数据;
	}
}
