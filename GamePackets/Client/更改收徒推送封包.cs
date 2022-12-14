using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 158, Length = 3, Description = "更改收徒推送")]
	public sealed class 更改收徒推送封包 : GamePacket
	{
		
		public 更改收徒推送封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public bool 收徒推送;
	}
}
