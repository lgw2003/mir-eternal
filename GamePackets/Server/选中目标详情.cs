using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 122, Length = 0, Description = "选中目标详情")]
	public sealed class 选中目标详情 : GamePacket
	{
		
		public 选中目标详情()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 8, Length = 4)]
		public int 当前体力;

		
		[WrappingFieldAttribute(SubScript = 12, Length = 4)]
		public int 当前魔力;

		
		[WrappingFieldAttribute(SubScript = 16, Length = 4)]
		public int 最大体力;

		
		[WrappingFieldAttribute(SubScript = 20, Length = 4)]
		public int 最大魔力;

		[WrappingFieldAttribute(SubScript = 25, Length = 1)]
		public byte[] Buff描述;
	}
}
