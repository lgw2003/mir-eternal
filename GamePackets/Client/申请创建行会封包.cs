using System;

namespace GameServer.Networking
{
	
	[PacketInfo(Source = PacketSource.Client, Id = 161, Length = 0, Description = "申请创建行会")]
	public sealed class 申请创建行会封包 : GamePacket
	{
		[WrappingField(SubScript = 2, Length = 0)]
		public byte[] Data;
	}
}
