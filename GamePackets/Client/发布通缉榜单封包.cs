using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 211, Length = 50, Description = "发布通缉榜单")]
	public sealed class 发布通缉榜单封包 : GamePacket
	{
		
		public 发布通缉榜单封包()
		{
			
			
		}
	}
}
