using GameServer.Maps;
using GameServer.Networking;
using GameServer.Templates;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.PlayerCommands
{
  public class PlayerCommandGlobalMessage : PlayerCommand
  {
    public override GameMasterLevel RequiredGMLevel => GameMasterLevel.Administrator;

    [Field(Position = 0)]
    public string GlobalMessageText;

    public override void Execute()
    {
      网络服务网关.发送公告($"{Player.ObjectName}: {GlobalMessageText}");
      Player.SendMessage("发送给所有玩家的信息:");
    }
  }
}
