using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 163, Length = 6, Description = "捐献行会资金")]
	public sealed class 捐献行会资金封包 : GamePacket
	{
		
		public 捐献行会资金封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int NumberGoldCoins;
	}
}
