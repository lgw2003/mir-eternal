using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 567, Length = 6, Description = "转移会长职位")]
	public sealed class 转移会长职位封包 : GamePacket
	{
		
		public 转移会长职位封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
