using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 664, Length = 226, Description = "树立城主雕像")]
	public sealed class 树立城主雕像 : GamePacket
	{
		
		public 树立城主雕像()
		{
			
			
		}
	}
}
