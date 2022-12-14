using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 314, Length = 0, Description = "接受通缉榜单")]
	public sealed class 接受通缉榜单 : GamePacket
	{
		
		public 接受通缉榜单()
		{
			
			
		}
	}
}
