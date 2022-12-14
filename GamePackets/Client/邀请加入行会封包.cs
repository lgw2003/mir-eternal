using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 559, Length = 34, Description = "邀请加入行会")]
	public sealed class 邀请加入行会封包 : GamePacket
	{
		
		public 邀请加入行会封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 32)]
		public string 对象名字;
	}
}
