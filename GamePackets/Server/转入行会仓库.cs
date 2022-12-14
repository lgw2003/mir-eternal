using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 614, Length = 0, Description = "转入行会仓库")]
	public sealed class 转入行会仓库 : GamePacket
	{
		
		public 转入行会仓库()
		{
			
			
		}
	}
}
