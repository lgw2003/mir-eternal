using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 614, Length = 3, Description = "登录寄售平台")]
	public sealed class 登录寄售平台封包 : GamePacket
	{
		
		public 登录寄售平台封包()
		{
			
			
		}
	}
}
