using GameServer;
using GameServer.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePackets.Server
{
    [PacketInfo(Source = PacketSource.Server, Id = 145, Length = 7, Description = "同步对象坐骑", Broadcast = true)]
    public class 同步对象坐骑 : GamePacket
    {
        [WrappingField(SubScript = 2, Length = 4)]
        public int 对象编号;

        [WrappingField(SubScript = 6, Length = 1)]
        public byte 坐骑编号;
    }
}
