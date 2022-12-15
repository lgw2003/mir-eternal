using GameServer.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.PlayerCommands
{
    public class PlayerCommandLevel : PlayerCommand
    {
        [Field(Position = 0)]
        public byte Level;

        public override void Execute()
        {
            if (Level <= 0 || Level > Config.游戏开放等级)
            {
                Player.SendMessage($"Invalid level, please provide one between 1-{Config.游戏开放等级}");
                return;
            }

            Player.CurrentLevel = Level;
            Player.CurrentExp = 0;
            Player.玩家升级处理();
            Player.SendPacket(new 角色经验变动
            {
                经验增加 = 0,
                今日增加 = 0,
                经验上限 = 10000000,
                DoubleExp = 0,
                CurrentExp = Player.CurrentExp,
                升级所需 = Player.MaxExperience,
                GainAwakeningExp = Player.CharacterData.觉醒经验.V,
                MaxAwakeningExp = Config.MaxAwakeningExp
            });

        }
    }
}
