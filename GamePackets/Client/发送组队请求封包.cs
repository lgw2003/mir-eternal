using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 516, Length = 6, Description = "发送组队请求")]
	public sealed class 发送组队请求封包 : GamePacket
	{
		
		public 发送组队请求封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
