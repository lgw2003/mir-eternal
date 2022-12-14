using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 256, Length = 2, Description = "放入升级武器")]
	public sealed class 放入升级武器 : GamePacket
	{
		
		public 放入升级武器()
		{
			
			
		}
	}
}
