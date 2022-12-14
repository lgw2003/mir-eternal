using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 544, Length = 7, Description = "发送收徒推送")]
	public sealed class 发送收徒推送 : GamePacket
	{
		
		public 发送收徒推送()
		{
			
			
		}
	}
}
