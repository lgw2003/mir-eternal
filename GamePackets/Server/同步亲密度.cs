using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 539, Length = 10, Description = "同步亲密度")]
	public sealed class 同步亲密度 : GamePacket
	{
		
		public 同步亲密度()
		{
			
			
		}
	}
}
