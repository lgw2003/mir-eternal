using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 640, Length = 10, Description = "解除敌对列表")]
	public sealed class 解除敌对列表 : GamePacket
	{
		
		public 解除敌对列表()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 申请类型;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int 行会编号;
	}
}
