using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 619, Length = 6, Description = "行会工资变动")]
	public sealed class 行会工资变动 : GamePacket
	{
		
		public 行会工资变动()
		{
			
			
		}
	}
}
