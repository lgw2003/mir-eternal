using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 134, Length = 3, Description = "切换地图路线")]
	public sealed class 切换地图路线封包 : GamePacket
	{
		
		public 切换地图路线封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 地图路线;
	}
}
