using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 39, Length = 5, Description = "装备技能")]
	public sealed class 玩家装备技能封包 : GamePacket
	{
		
		public 玩家装备技能封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 技能栏位;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 2)]
		public ushort 技能编号;
	}
}
