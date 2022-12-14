using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 687, Length = 499, Description = "跨服武道排名")]
	public sealed class 同步武道排名 : GamePacket
	{
		
		public 同步武道排名()
		{
			
			
		}
	}
}
