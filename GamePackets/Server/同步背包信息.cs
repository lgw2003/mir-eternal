using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 17, Length = 0, Description = "同步背包信息")]
	public sealed class 同步背包信息 : GamePacket
	{
		
		public 同步背包信息()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 6, Length = 0)]
		public byte[] 物品描述;
	}
}
