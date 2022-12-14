using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 586, Length = 231, Description = "查找行会应答")]
	public sealed class 查找行会应答 : GamePacket
	{
		
		public 查找行会应答()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 229)]
		public byte[] 字节数据;
	}
}
