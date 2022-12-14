using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 566, Length = 6, Description = "逐出行会成员")]
	public sealed class 逐出行会成员封包 : GamePacket
	{
		
		public 逐出行会成员封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
