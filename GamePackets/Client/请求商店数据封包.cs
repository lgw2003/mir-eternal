using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 65, Length = 6, Description = "请求商店数据")]
	public sealed class 请求商店数据封包 : GamePacket
	{
		
		public 请求商店数据封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 版本编号;
	}
}
