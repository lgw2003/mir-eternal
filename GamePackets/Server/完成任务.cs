using GameServer;
using GameServer.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePackets.Server
{
    [PacketInfo(Source = PacketSource.Server, Id = 166, Length = 6, Description = "完成任务")]
    public class 完成任务 : GamePacket
    {
        [WrappingField(SubScript = 2, Length = 4)]
        public int 任务编号;
    }
}
