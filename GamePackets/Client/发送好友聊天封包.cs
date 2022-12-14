using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 526, Length = 0, Description = "好友聊天")]
	public sealed class 发送好友聊天封包 : GamePacket
	{
		
		public 发送好友聊天封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 0)]
		public byte[] 字节数据;
	}
}
