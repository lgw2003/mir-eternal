using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 616, Length = 6, Description = "查询指定商品")]
	public sealed class 查询指定商品封包 : GamePacket
	{
		
		public 查询指定商品封包()
		{
			
			
		}
	}
}
