using GameServer;
using GameServer.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePackets.Server
{
    [PacketInfo(Source = PacketSource.Server, Id = 273, Length = 3, Description = "同步仓库锁封包")]
    public class 同步仓库锁封包 : GamePacket
    {
        [WrappingField(SubScript = 2, Length = 1)]
        public bool Enabled;
    }
}
