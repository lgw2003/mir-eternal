using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 87, Length = 94, Description = "SyncMasterRewardPacket(师徒通用)")]
	public sealed class 同步师门奖励 : GamePacket
	{
		
		public 同步师门奖励()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 92)]
		public byte[] 字节数据;
	}
}
