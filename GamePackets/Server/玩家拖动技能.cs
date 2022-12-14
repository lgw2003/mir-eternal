using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 100, Length = 7, Description = "角色拖动技能")]
	public sealed class 玩家拖动技能 : GamePacket
	{
		
		public 玩家拖动技能()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 技能栏位;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 2)]
		public ushort SkillId;

		
		[WrappingFieldAttribute(SubScript = 5, Length = 1)]
		public byte Id;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 1)]
		public byte SkillLevel;
	}
}
