using GameServer;
using GameServer.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePackets.Server
{
    [PacketInfo(Source = PacketSource.Server, Id = 317, Length = 3, Description = "同步选中坐骑")]
    public class 同步选中坐骑 : GamePacket
    {
        [WrappingField(SubScript = 2, Length = 1)]
        public byte SelectedMountId;
    }
}
