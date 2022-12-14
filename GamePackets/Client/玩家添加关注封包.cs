using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 522, Length = 38, Description = "AddFriendsToFollowPacket")]
	public sealed class 玩家添加关注封包 : GamePacket
	{
		
		public 玩家添加关注封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 32)]
		public string 对象名字;
	}
}
