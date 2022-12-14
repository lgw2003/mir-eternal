using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 656, Length = 6, Description = "同步元宝数量")]
	public sealed class 同步元宝数量 : GamePacket
	{
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int Ingots;
	}
}
