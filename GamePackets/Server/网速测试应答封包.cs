using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 45, Length = 6, Description = "同步游戏ping", NoDebug = true)]
	public sealed class 网速测试应答封包 : GamePacket
	{
		
		public 网速测试应答封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 当前时间;
	}
}
