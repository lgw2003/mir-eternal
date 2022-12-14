using System;

namespace GameServer.Networking
{
	
	[PacketInfo(Source = PacketSource.Client, Id = 113, Length = 14, Description = "点击Npcc对话")]
	public sealed class 点击Npcc对话封包 : GamePacket
	{
		[WrappingField(SubScript = 2, Length = 4)]
		public int 对象编号;

		[WrappingField(SubScript = 6, Length = 4)]
		public int 任务编号;

		[WrappingField(SubScript = 10, Length = 4)]
		public int Unknown;
	}
}
