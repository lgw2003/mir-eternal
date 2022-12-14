using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 599, Length = 6, Description = "查询珍宝商店")]
	public sealed class 查询珍宝商店封包 : GamePacket
	{
		
		public 查询珍宝商店封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 数据版本;
	}
}
