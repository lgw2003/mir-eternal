using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 40, Length = 4, Description = "战斗姿态切换封包")]
	public sealed class 战斗姿态切换封包 : GamePacket
	{
		
		public 战斗姿态切换封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public bool 切回正常姿态;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 1)]
		public bool 系统自动切换;
	}
}
