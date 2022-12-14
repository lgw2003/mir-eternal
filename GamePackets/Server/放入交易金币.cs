using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 217, Length = 10, Description = "放入交易金币")]
	public sealed class 放入交易金币 : GamePacket
	{
		
		public 放入交易金币()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int NumberGoldCoins;
	}
}
