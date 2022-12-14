using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 1006, Length = 6, Description = "进入游戏")]
	public sealed class 玩家进入游戏封包 : GamePacket
	{
		
		public 玩家进入游戏封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 角色编号;
	}
}
