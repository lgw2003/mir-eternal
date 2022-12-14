using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 566, Length = 6, Description = "逐出师门提示")]
	public sealed class 逐出师门提示 : GamePacket
	{
		
		public 逐出师门提示()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
