using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 1005, Length = 96, Description = "角色创建成功")]
	public sealed class 角色创建成功 : GamePacket
	{
		
		public 角色创建成功()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 94)]
		public byte[] 角色描述;
	}
}
