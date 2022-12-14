using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 663, Length = 6, Description = "行会攻城登记")]
	public sealed class 行会攻城登记 : GamePacket
	{
		
		public 行会攻城登记()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 行会编号;
	}
}
