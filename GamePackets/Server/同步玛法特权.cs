using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 332, Length = 3, Description = "同步玛法特权")]
	public sealed class 同步玛法特权 : GamePacket
	{
		
		public 同步玛法特权()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 玛法特权;
	}
}
