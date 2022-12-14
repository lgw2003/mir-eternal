using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 127, Length = 7, Description = "同步技能等级数据")]
	public sealed class 同步技能等级 : GamePacket
	{
		
		public 同步技能等级()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 2)]
		public ushort 技能编号;

		
		[WrappingFieldAttribute(SubScript = 4, Length = 2)]
		public ushort 当前经验;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 1)]
		public byte 当前等级;
	}
}
