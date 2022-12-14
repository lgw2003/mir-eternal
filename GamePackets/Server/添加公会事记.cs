using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 617, Length = 23, Description = "添加公会事记")]
	public sealed class 添加公会事记 : GamePacket
	{
		
		public 添加公会事记()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 事记类型;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 4)]
		public int 第一参数;

		
		[WrappingFieldAttribute(SubScript = 7, Length = 4)]
		public int 第二参数;

		
		[WrappingFieldAttribute(SubScript = 11, Length = 4)]
		public int 第三参数;

		
		[WrappingFieldAttribute(SubScript = 15, Length = 4)]
		public int 第四参数;

		
		[WrappingFieldAttribute(SubScript = 19, Length = 4)]
		public int 事记时间;
	}
}
