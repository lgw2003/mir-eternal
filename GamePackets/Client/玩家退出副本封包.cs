using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 11, Length = 2, Description = "ExitCurrentCopyPacket")]
	public sealed class 玩家退出副本封包 : GamePacket
	{
		
		public 玩家退出副本封包()
		{
			
			
		}
	}
}
