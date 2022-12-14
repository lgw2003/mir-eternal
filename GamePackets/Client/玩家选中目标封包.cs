using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 31, Length = 6, Description = "玩家选中目标")]
	public sealed class 玩家选中目标封包 : GamePacket
	{
		
		public 玩家选中目标封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
