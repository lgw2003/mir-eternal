using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 587, Length = 0, Description = "行会信息公告")]
	public sealed class 行会信息公告 : GamePacket
	{
		
		public 行会信息公告()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 字节数据;
	}
}
