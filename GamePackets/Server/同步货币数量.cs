using System;

namespace GameServer.Networking
{
	
	[PacketInfo(Source = PacketSource.Server, Id = 148, Length = 0, Description = "同步货币数量")]
	public sealed class 同步货币数量 : GamePacket
	{
		
		[WrappingField(SubScript = 4, Length = 1)]
		public byte U1 = 1;
		
		[WrappingField(SubScript = 5, Length = 0)]
		public byte[] 字节描述;
	}
}
