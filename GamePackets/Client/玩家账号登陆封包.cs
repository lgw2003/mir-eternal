using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 1001, Length = 162, Description = "客户登录")]
	public sealed class 玩家账号登陆封包 : GamePacket
	{
		[WrappingFieldAttribute(SubScript = 72, Length = 38)]
		public string 登陆门票;

		[WrappingFieldAttribute(SubScript = 136, Length = 17)]
		public string MacAddress;

		public 玩家账号登陆封包()
		{
			是否加密 = false;
		}
	}
}
