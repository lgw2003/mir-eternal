using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 595, Length = 35, Description = "行会邀请应答")]
	public sealed class 行会邀请应答 : GamePacket
	{
		
		public 行会邀请应答()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 应答类型;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 32)]
		public string 对象名字;
	}
}
