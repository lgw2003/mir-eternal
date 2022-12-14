using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 312, Length = 0, Description = "同步通缉名单")]
	public sealed class 同步通缉名单 : GamePacket
	{
		
		public 同步通缉名单()
		{
			
			
		}
	}
}
