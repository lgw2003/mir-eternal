using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 574, Length = 2, Description = "更多行会事记")]
	public sealed class 更多行会事记封包 : GamePacket
	{
		
		public 更多行会事记封包()
		{
			
			
		}
	}
}
