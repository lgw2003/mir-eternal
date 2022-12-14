using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 682, Length = 326, Description = "演武挑战榜单")]
	public sealed class 演武挑战榜单 : GamePacket
	{
		
		public 演武挑战榜单()
		{
			
			
		}
	}
}
