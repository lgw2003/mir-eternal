using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 565, Length = 6, Description = "逐出师门应答")]
	public sealed class 逐出师门应答 : GamePacket
	{
		
		public 逐出师门应答()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
