using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 548, Length = 2, Description = "查询邮箱内容")]
	public sealed class 查询邮箱内容封包 : GamePacket
	{
		
		public 查询邮箱内容封包()
		{
			
			
		}
	}
}
