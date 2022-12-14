using System;

namespace GameServer.Networking
{
	
	[PacketInfo(Source = PacketSource.Server, Id = 90, Length = 4, Description = "角色移除技能")]
	public sealed class 角色移除技能 : GamePacket
	{
        [WrappingField(SubScript = 2, Length = 2)]
        public ushort SkillId;
    }
}
