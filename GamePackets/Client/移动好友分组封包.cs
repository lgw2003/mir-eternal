using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 524, Length = 7, Description = "移动好友分组(已屏蔽)")]
	public sealed class 移动好友分组封包 : GamePacket
	{
		
		public 移动好友分组封包()
		{
			
			
		}
	}
}
