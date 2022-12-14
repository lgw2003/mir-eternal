using System;

namespace GameServer.Networking
{
	
	[PacketInfo(Source = PacketSource.Server, Id = 78, Length = 14, Description = "同步对象体力", Broadcast = true)]
	public sealed class 同步对象体力 : GamePacket
	{
		[WrappingField(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingField(SubScript = 6, Length = 4)]
		public int 当前体力;

		
		[WrappingField(SubScript = 10, Length = 4)]
		public int 体力上限;
	}
}
