using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 681, Length = 38, Description = "演武对象信息")]
	public sealed class 演武对象信息 : GamePacket
	{
		
		public 演武对象信息()
		{
			
			
		}
	}
}
