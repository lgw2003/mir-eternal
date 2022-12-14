using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 1005, Length = 6, Description = "玩家找回角色")]
	public sealed class 玩家找回角色封包 : GamePacket
	{
		
		public 玩家找回角色封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 角色编号;
	}
}
