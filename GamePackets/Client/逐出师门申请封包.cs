using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 543, Length = 6, Description = "逐出师门申请")]
	public sealed class 逐出师门申请封包 : GamePacket
	{
		
		public 逐出师门申请封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
