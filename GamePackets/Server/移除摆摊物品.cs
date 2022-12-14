using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 158, Length = 3, Description = "移除摆摊物品")]
	public sealed class 移除摆摊物品 : GamePacket
	{
		
		public 移除摆摊物品()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 取回位置;
	}
}
