using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 604, Length = 10, Description = "属性修改通知")]
	public sealed class 属性修改通知 : GamePacket
	{
		
		public 属性修改通知()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int Stat类型;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int Value;
	}
}
