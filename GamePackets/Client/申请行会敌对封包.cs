using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 584, Length = 28, Description = "申请行会敌对")]
	public sealed class 申请行会敌对封包 : GamePacket
	{
		
		public 申请行会敌对封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 敌对时间;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 25)]
		public string 行会名称;
	}
}
