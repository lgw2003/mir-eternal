using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 593, Length = 6, Description = "行会移除成员")]
	public sealed class 行会移除成员 : GamePacket
	{
		
		public 行会移除成员()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
