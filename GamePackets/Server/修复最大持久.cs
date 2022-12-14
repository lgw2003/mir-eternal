using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 343, Length = 3, Description = "修复最大持久")]
	public sealed class 修复最大持久 : GamePacket
	{
		
		public 修复最大持久()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public bool 修复失败;
	}
}
