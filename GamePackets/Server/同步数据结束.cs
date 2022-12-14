using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 33, Length = 6, Description = "同步数据结束")]
	public sealed class 同步数据结束 : GamePacket
	{
		
		public 同步数据结束()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 角色编号;
	}
}
