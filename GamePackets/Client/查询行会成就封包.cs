using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 580, Length = 2, Description = "查询行会成就")]
	public sealed class 查询行会成就封包 : GamePacket
	{
		
		public 查询行会成就封包()
		{
			
			
		}
	}
}
