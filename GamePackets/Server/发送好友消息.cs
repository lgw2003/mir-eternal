using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 536, Length = 0, Description = "好友聊天")]
	public sealed class 发送好友消息 : GamePacket
	{
		
		public 发送好友消息()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 字节数据;
	}
}
