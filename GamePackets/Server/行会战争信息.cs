using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 639, Length = 14, Description = "行会战争信息")]
	public sealed class 行会战争信息 : GamePacket
	{
		
		public 行会战争信息()
		{
			
			
		}
	}
}
