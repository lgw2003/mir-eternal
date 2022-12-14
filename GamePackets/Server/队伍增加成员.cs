using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 518, Length = 45, Description = "队伍增加成员")]
	public sealed class 队伍增加成员 : GamePacket
	{
		
		public 队伍增加成员()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 队伍编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 10, Length = 32)]
		public string 对象名字;

		
		[WrappingFieldAttribute(SubScript = 42, Length = 1)]
		public byte 对象性别;

		
		[WrappingFieldAttribute(SubScript = 43, Length = 1)]
		public byte 对象职业;

		
		[WrappingFieldAttribute(SubScript = 44, Length = 1)]
		public byte 在线离线;
	}
}
