using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 553, Length = 6, Description = "拒绝拜师提示")]
	public sealed class 拒绝拜师提示 : GamePacket
	{
		
		public 拒绝拜师提示()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
