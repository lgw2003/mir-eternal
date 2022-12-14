using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 14, Length = 0, Description = "同步角色Stat")]
	public sealed class 同步角色属性 : GamePacket
	{
		
		public 同步角色属性()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 6, Length = 0)]
		public byte[] 属性描述;
	}
}
