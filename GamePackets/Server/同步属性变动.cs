using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 77, Length = 7, Description = "同步属性变动")]
	public sealed class 同步属性变动 : GamePacket
	{
		
		public 同步属性变动()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 属性编号;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 4)]
		public int 属性数值;
	}
}
