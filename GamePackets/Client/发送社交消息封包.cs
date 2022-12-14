using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 529, Length = 0, Description = "发送社交消息(公会/队伍/私人)")]
	public sealed class 发送社交消息封包 : GamePacket
	{
		
		public 发送社交消息封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 0)]
		public byte[] 字节数据;
	}
}
