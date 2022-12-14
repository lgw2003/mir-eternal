using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 18, Length = 0, Description = "同步技能信息")]
	public sealed class 同步技能信息 : GamePacket
	{
		
		public 同步技能信息()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 技能描述;
	}
}
