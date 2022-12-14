using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 32, Length = 15, Description = "不知道干嘛的, 离开进入安全区触发")]
	public sealed class 预留封包零一 : GamePacket
	{
		
		public 预留封包零一()
		{
			
			
		}
	}
}
