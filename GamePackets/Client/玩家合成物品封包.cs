using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 87, Length = 6, Description = "CharacterSynthesisItemPacket")]
	public sealed class 玩家合成物品封包 : GamePacket
	{
		
		public 玩家合成物品封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte Id;
	}
}
