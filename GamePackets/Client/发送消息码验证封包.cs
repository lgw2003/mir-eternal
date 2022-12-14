using GameServer;
using GameServer.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePackets.Client
{
    [PacketInfo(Source = PacketSource.Client, Id = 610, Length = 9, Description = "发送消息码验证封包")]
    public class 发送消息码验证封包 : GamePacket
    {
        [WrappingField(SubScript = 2, Length = 7)]
        public string Code;
    }
}
