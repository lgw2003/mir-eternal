using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 568, Length = 6, Description = "移除徒弟提示")]
	public sealed class 移除徒弟提示 : GamePacket
	{
		
		public 移除徒弟提示()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
