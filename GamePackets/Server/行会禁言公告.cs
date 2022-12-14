using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 598, Length = 7, Description = "行会禁言公告")]
	public sealed class 行会禁言公告 : GamePacket
	{
		
		public 行会禁言公告()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 1)]
		public byte 禁言状态;
	}
}
