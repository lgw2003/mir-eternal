using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 560, Length = 6, Description = "拒绝收徒提示")]
	public sealed class 拒绝收徒提示 : GamePacket
	{
		
		public 拒绝收徒提示()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
