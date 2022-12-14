using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 545, Length = 0, Description = "祝贺徒弟升级(已弃用)")]
	public sealed class 祝贺徒弟升级封包 : GamePacket
	{
		
		public 祝贺徒弟升级封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 0)]
		public byte[] 字节数据;
	}
}
