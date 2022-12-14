using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 179, Length = 0, Description = "接收聊天信息(附近)", Broadcast = true)]
	public sealed class 接收聊天信息 : GamePacket
	{
		
		public 接收聊天信息()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 字节描述;
	}
}
