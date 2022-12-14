using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 217, Length = 3, Description = "预定玛法特权")]
	public sealed class 预定玛法特权封包 : GamePacket
	{
		
		public 预定玛法特权封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 特权类型;
	}
}
