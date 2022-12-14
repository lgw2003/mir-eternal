using GameServer;
using GameServer.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePackets.Client
{
    [PacketInfo(Source = PacketSource.Client, Id = 157, Length = 6, Description = "接受奖励封包")]
    public class 接受奖励封包 : GamePacket
    {
        [WrappingField(SubScript = 2, Length = 4)]
        public int QuestId;
    }
}
