using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 67, Length = 93, Description = "同步玩家数据")]
	public sealed class 同步玩家数据 : GamePacket
	{
		
		public 同步玩家数据()
		{
			
			
		}
	}
}
