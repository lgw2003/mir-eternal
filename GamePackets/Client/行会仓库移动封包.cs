using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 573, Length = 8, Description = "行会仓库移动")]
	public sealed class 行会仓库移动封包 : GamePacket
	{
		
		public 行会仓库移动封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 原有页面;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 1)]
		public byte 原有位置;

		
		[WrappingFieldAttribute(SubScript = 4, Length = 1)]
		public byte 目标页面;

		
		[WrappingFieldAttribute(SubScript = 5, Length = 1)]
		public byte 目标位置;
	}
}
