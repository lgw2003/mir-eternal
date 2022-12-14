using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 596, Length = 2, Description = "解散行会公告")]
	public sealed class 解散行会公告 : GamePacket
	{
		
		public 解散行会公告()
		{
			
			
		}
	}
}
