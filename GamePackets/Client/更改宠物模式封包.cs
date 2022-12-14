using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 190, Length = 3, Description = "更改宠物模式")]
	public sealed class 更改宠物模式封包 : GamePacket
	{
		
		public 更改宠物模式封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte PetMode;
	}
}
