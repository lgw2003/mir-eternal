using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 51, Length = 2, Description = "查询回购列表封包")]
	public sealed class 查询回购列表封包 : GamePacket
	{
		
		public 查询回购列表封包()
		{
			
			
		}
	}
}
