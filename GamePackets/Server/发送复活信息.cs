using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 57, Length = 55, Description = "复活信息(无此封包不会弹出复活框)")]
	public sealed class 发送复活信息 : GamePacket
	{
		
		public 发送复活信息()
		{
			
			this.复活描述 = new byte[]
			{
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				161,
				134,
				1,
				0,
				1,
				0,
				0,
				0,
				2,
				1,
				0,
				0,
				0,
				100,
				0,
				0,
				0,
				3,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				4,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0
			};
			
		}

		
		public byte[] 复活描述;
	}
}
