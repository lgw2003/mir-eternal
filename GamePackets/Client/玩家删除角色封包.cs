using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 1003, Length = 6, Description = "删除角色")]
	public sealed class 玩家删除角色封包 : GamePacket
	{
		
		public 玩家删除角色封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 角色编号;
	}
}
