using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 637, Length = 7, Description = "行会战争公告")]
	public sealed class 行会战争公告 : GamePacket
	{
		
		public 行会战争公告()
		{
			
			
		}
	}
}
