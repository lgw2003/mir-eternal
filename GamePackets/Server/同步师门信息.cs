using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 25, Length = 8, Description = "同步师门信息")]
	public sealed class 同步师门信息 : GamePacket
	{
		
		public 同步师门信息()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 限制时间;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 1)]
		public byte 师门参数;

		
		[WrappingFieldAttribute(SubScript = 7, Length = 1)]
		public byte 师门推送;
	}
}
