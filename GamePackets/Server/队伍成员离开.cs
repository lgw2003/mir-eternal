using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 519, Length = 10, Description = "队伍成员离开")]
	public sealed class 队伍成员离开 : GamePacket
	{
		
		public 队伍成员离开()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 队伍编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int 对象编号;
	}
}
