using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 322, Length = 0, Description = "同步特权信息")]
	public sealed class 同步特权信息 : GamePacket
	{
		
		public 同步特权信息()
		{
			
			this.字节数组 = new byte[]
			{
				2
			};
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 字节数组;
	}
}
