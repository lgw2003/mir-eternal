using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 603, Length = 10, Description = "捐献资源应答")]
	public sealed class 捐献资源应答 : GamePacket
	{
		
		public 捐献资源应答()
		{
			
			
		}
	}
}
