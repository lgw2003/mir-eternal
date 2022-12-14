using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 659, Length = 0, Description = "珍宝商店日志")]
	public sealed class 珍宝商店日志 : GamePacket
	{
		
		public 珍宝商店日志()
		{
			
			
		}
	}
}
