using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 135, Length = 28, Description = "新建好友分组(已屏蔽)")]
	public sealed class 新建好友分组封包 : GamePacket
	{
		
		public 新建好友分组封包()
		{
			
			
		}
	}
}
