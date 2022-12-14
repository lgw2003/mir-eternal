using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 109, Length = 10, Description = "添加技能冷却")]
	public sealed class 添加技能冷却 : GamePacket
	{
		[WrappingFieldAttribute(SubScript = 2, Length = 2)]
		public int CoolingId;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int Cooldown;
	}
}
