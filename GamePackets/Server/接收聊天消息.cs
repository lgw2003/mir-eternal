using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 540, Length = 0, Description = "接收聊天消息(系统/私聊/广播/传音/公会/队伍)")]
	public sealed class 接收聊天消息 : GamePacket
	{
		
		public 接收聊天消息()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 字节描述;
	}
}
