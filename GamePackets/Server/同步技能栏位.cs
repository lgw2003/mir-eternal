using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 19, Length = 0, Description = "同步技能栏位")]
	public sealed class 同步技能栏位 : GamePacket
	{
		
		public 同步技能栏位()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 栏位描述;
	}
}
