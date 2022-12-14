using GameServer;
using GameServer.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePackets.Client
{
    [PacketInfo(Source = PacketSource.Client, Id = 98, Length = 3, Description = "玩家仓库锁定")]
    public class 玩家仓库锁定封包 : GamePacket
    {
        [WrappingField(SubScript = 2, Length = 1)]
        public bool Enabled;
    }
}
