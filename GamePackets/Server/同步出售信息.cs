using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 660, Length = 0, Description = "查询出售信息")]
	public sealed class 同步出售信息 : GamePacket
	{
		
		public 同步出售信息()
		{
			
			
		}
	}
}
