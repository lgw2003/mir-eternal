using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 248, Length = 6, Description = "进入演武战场")]
	public sealed class 进入演武战场封包 : GamePacket
	{
		
		public 进入演武战场封包()
		{
			
			
		}
	}
}
