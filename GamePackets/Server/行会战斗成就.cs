using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 633, Length = 0, Description = "帮会战斗成就")]
	public sealed class 行会战斗成就 : GamePacket
	{
		
		public 行会战斗成就()
		{
			
			
		}
	}
}
