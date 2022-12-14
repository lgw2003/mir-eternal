using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 134, Length = 2, Description = "修理物品应答")]
	public sealed class 修理物品应答 : GamePacket
	{
		
		public 修理物品应答()
		{
			
			
		}
	}
}
