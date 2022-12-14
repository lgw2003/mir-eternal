using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 33, Length = 4, Description = "角色开关技能")]
	public sealed class 玩家开关技能封包 : GamePacket
	{
		
		public 玩家开关技能封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 2)]
		public ushort SkillId;
	}
}
