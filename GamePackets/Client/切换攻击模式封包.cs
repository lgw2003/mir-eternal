using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 38, Length = 3, Description = "切换攻击模式")]
	public sealed class 切换攻击模式封包 : GamePacket
	{
		
		public 切换攻击模式封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte AttackMode;
	}
}
