using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 161, Length = 0, Description = "同步摊位数据")]
	public sealed class 同步摊位数据 : GamePacket
	{
		
		public 同步摊位数据()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 8, Length = 0)]
		public byte[] 字节数据;
	}
}
