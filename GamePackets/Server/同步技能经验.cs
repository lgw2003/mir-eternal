using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 126, Length = 6, Description = "同步技能经验")]
	public sealed class 同步技能经验 : GamePacket
	{
		
		public 同步技能经验()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 2)]
		public ushort 技能编号;

		
		[WrappingFieldAttribute(SubScript = 4, Length = 2)]
		public ushort 当前经验;
	}
}
