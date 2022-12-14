using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 569, Length = 2, Description = "清空师门信息")]
	public sealed class 清空师门信息 : GamePacket
	{
		
		public 清空师门信息()
		{
			
			
		}
	}
}
