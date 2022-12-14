using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 1, Length = 15, Description = "网关查询应答")]
	public sealed class 网关查询应答 : GamePacket
	{
		
		public 网关查询应答()
		{
			
			
		}
	}
}
