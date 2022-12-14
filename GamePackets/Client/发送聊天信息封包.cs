using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 131, Length = 0, Description = "发送聊天信息(附近|广播|传音)")]
	public sealed class 发送聊天信息封包 : GamePacket
	{
		
		public 发送聊天信息封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 0)]
		public byte[] 字节数据;
	}
}
