using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 215, Length = 11, Description = "交易状态改变")]
	public sealed class 交易状态改变 : GamePacket
	{
		
		public 交易状态改变()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 1)]
		public byte 交易状态;

		
		[WrappingFieldAttribute(SubScript = 7, Length = 4)]
		public int 对象等级;
	}
}
