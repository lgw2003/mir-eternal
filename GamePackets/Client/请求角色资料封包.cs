using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 515, Length = 10, Description = "请求角色资料")]
	public sealed class 请求角色资料封包 : GamePacket
	{
		
		public 请求角色资料封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 角色编号;
	}
}
