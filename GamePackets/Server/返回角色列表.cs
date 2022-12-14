using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 1004, Length = 849, Description = "同步角色列表")]
	public sealed class 返回角色列表 : GamePacket
	{
		
		public 返回角色列表()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 846)]
		public byte[] 列表描述;
	}
}
