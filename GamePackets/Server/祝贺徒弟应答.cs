using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 571, Length = 6, Description = "祝贺徒弟应答")]
	public sealed class 祝贺徒弟应答 : GamePacket
	{
		
		public 祝贺徒弟应答()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 徒弟编号;
	}
}
