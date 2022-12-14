using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 572, Length = 6, Description = "徒弟成功出师")]
	public sealed class 徒弟成功出师 : GamePacket
	{
		
		public 徒弟成功出师()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
