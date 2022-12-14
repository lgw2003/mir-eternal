using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 164, Length = 8, Description = "行会仓库刷新")]
	public sealed class 行会仓库刷新封包 : GamePacket
	{
		
		public 行会仓库刷新封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 仓库页面;
	}
}
