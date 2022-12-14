using GameServer;
using GameServer.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePackets.Client
{
    [PacketInfo(Source = PacketSource.Client, Id = 226, Length = 4, Description = "升级觉醒技能封包")]
    public class 升级觉醒技能封包 : GamePacket
    {
        [WrappingField(SubScript = 2, Length = 2)]
        public ushort SkillId;
    }
}
