using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 1002, Length = 0, Description = "客户端登录成功,同步协议")]
	public sealed class 账号成功登陆 : GamePacket
	{
		
		public override bool 是否加密 { get; set; }

		
		public 账号成功登陆()
		{
			this.是否加密 = false;

		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 协议数据;
	}
}
