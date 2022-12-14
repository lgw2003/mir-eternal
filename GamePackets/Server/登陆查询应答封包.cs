using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 1010, Length = 6, Description = "同步网关Ping", NoDebug = true)]
	public sealed class 登陆查询应答封包 : GamePacket
	{
		
		public 登陆查询应答封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 当前时间;
	}
}
