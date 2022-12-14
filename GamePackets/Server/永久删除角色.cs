using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 1008, Length = 6, Description = "永久删除角色回应")]
	public sealed class 永久删除角色 : GamePacket
	{
		
		public 永久删除角色()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 角色编号;
	}
}
