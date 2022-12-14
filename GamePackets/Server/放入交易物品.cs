using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 216, Length = 0, Description = "放入交易物品")]
	public sealed class 放入交易物品 : GamePacket
	{
		
		public 放入交易物品()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 8, Length = 1)]
		public byte 放入位置;

		
		[WrappingFieldAttribute(SubScript = 9, Length = 1)]
		public byte 放入物品;

		
		[WrappingFieldAttribute(SubScript = 10, Length = 0)]
		public byte[] 物品描述;
	}
}
