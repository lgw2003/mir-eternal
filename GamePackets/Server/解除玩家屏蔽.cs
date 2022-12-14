using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 251, Length = 6, Description = "解除玩家屏蔽")]
	public sealed class 解除玩家屏蔽 : GamePacket
	{
		
		public 解除玩家屏蔽()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
