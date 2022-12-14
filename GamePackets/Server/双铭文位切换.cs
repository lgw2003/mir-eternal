using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 267, Length = 8, Description = "双铭文位切换")]
	public sealed class 双铭文位切换 : GamePacket
	{
		
		public 双铭文位切换()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 2)]
		public ushort 当前栏位;

		
		[WrappingFieldAttribute(SubScript = 4, Length = 2)]
		public ushort 第一铭文;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 2)]
		public ushort 第二铭文;
	}
}
