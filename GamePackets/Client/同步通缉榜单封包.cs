using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 212, Length = 2, Description = "同步通缉榜单")]
	public sealed class 同步通缉榜单封包 : GamePacket
	{
		
		public 同步通缉榜单封包()
		{
			
			
		}
	}
}
