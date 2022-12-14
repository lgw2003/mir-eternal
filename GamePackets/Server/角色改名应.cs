using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 1011, Length = 38, Description = "更改角色姓名")]
	public sealed class 角色改名应 : GamePacket
	{
		
		public 角色改名应()
		{
			
			
		}
	}
}
