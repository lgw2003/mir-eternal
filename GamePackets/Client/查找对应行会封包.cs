using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 555, Length = 31, Description = "查找对应行会")]
	public sealed class 查找对应行会封包 : GamePacket
	{
		
		public 查找对应行会封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 行会编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 25)]
		public string 行会名称;
	}
}
