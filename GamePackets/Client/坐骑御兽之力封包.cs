using GameServer;
using GameServer.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePackets.Client
{
    [PacketInfo(Source = PacketSource.Client, Id = 219, Length = 5, Description = "坐骑御兽之力")]
    public class 坐骑御兽之力封包 : GamePacket
    {
        [WrappingField(SubScript = 2, Length = 2)]
        public ushort 坐骑编号;

        [WrappingField(SubScript = 4, Length = 1)]
        public byte Unknown;
    }
}
