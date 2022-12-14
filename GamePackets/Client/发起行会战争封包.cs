using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 579, Length = 27, Description = "发起行会战争")]
	public sealed class 发起行会战争封包 : GamePacket
	{
		
		public 发起行会战争封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 25)]
		public string GuildName;
	}
}
