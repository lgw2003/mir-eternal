using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 683, Length = 558, Description = "演武场挑战榜")]
	public sealed class 演武场挑战榜 : GamePacket
	{
		
		public 演武场挑战榜()
		{
			
			
		}
	}
}
