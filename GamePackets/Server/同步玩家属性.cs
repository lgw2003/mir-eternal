using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 34, Length = 0, Description = "同步玩家属性")]
	public sealed class 同步玩家属性 : GamePacket
	{
		
		public 同步玩家属性()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 8, Length = 4)]
		public int Stat数量;
	}
}
