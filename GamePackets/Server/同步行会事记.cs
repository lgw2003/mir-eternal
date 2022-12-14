using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 620, Length = 0, Description = "更多行会事记")]
	public sealed class 同步行会事记 : GamePacket
	{
		
		public 同步行会事记()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 字节数据;
	}
}
