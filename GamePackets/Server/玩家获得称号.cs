using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 213, Length = 7, Description = "玩家获得称号")]
	public sealed class 玩家获得称号 : GamePacket
	{
		
		public 玩家获得称号()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 称号编号;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 4)]
		public int 剩余时间;
	}
}
