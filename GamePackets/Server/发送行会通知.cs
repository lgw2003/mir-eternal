using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 610, Length = 3, Description = "发送行会通知")]
	public sealed class 发送行会通知 : GamePacket
	{
		
		public 发送行会通知()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 提醒类型;
	}
}
