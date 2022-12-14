using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 618, Length = 107, Description = "添加仓库公告")]
	public sealed class 添加仓库公告 : GamePacket
	{
		
		public 添加仓库公告()
		{
			
			
		}
	}
}
