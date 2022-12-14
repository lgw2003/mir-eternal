using GameServer;
using GameServer.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePackets.Client
{
    [PacketInfo(Source = PacketSource.Client, Id = 218, Length = 3, Description = "当前选中坐骑")]
    public class 当前选中坐骑封包 : GamePacket
    {
        [WrappingField(SubScript = 2, Length = 1)]
        public byte 坐骑编号;
    }
}
