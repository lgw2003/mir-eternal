using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 152, Length = 19, Description = "游戏道具出现")]
	public sealed class 游戏道具出现 : GamePacket
	{
		
		public 游戏道具出现()
		{
			
			
		}
	}
}
