using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 176, Length = 0, Description = "发放行会福利")]
	public sealed class 发放行会福利封包 : GamePacket
	{
		
		public 发放行会福利封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 1)]
		public byte 发放方式;

		
		[WrappingFieldAttribute(SubScript = 5, Length = 4)]
		public int 发放总额;

		
		[WrappingFieldAttribute(SubScript = 13, Length = 2)]
		public ushort 发放人数;

		
		[WrappingFieldAttribute(SubScript = 15, Length = 0)]
		public int 对象编号;
	}
}
