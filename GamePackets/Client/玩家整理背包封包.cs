using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 58, Length = 3, Description = "CharacterOrganizerBackpackPacket")]
	public sealed class 玩家整理背包封包 : GamePacket
	{
		
		public 玩家整理背包封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 背包类型;
	}
}
