using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 1007, Length = 6, Description = "找回角色应答回应")]
	public sealed class 找回角色应答 : GamePacket
	{
		
		public 找回角色应答()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 角色编号;
	}
}
