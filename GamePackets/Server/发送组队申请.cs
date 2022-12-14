using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 520, Length = 40, Description = "发送组队申请")]
	public sealed class 发送组队申请 : GamePacket
	{
		
		public 发送组队申请()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 1)]
		public byte 组队方式;

		
		[WrappingFieldAttribute(SubScript = 7, Length = 1)]
		public byte 对象职业;

		
		[WrappingFieldAttribute(SubScript = 8, Length = 32)]
		public string 对象名字;
	}
}
