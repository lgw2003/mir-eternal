using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 576, Length = 14, Description = "邮件删除成功")]
	public sealed class 邮件删除成功 : GamePacket
	{
		
		public 邮件删除成功()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int 邮件编号;
	}
}
