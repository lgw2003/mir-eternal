using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 231, Length = 6, Description = "请求魂石数据")]
	public sealed class 请求魂石数据封包 : GamePacket
	{
		
		public 请求魂石数据封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
