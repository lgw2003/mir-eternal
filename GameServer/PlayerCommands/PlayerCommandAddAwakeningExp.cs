using GameServer.Data;
using GameServer.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.PlayerCommands
{
    public class PlayerCommandAddAwakeningExp : PlayerCommand
    {
        [Field(Position = 0)]
        public int Amount;

        public override void Execute()
        {
            if (Amount + Player.CharacterData.觉醒经验.V > Config.MaxAwakeningExp)
            {
                Amount = Config.MaxAwakeningExp - Player.CharacterData.觉醒经验.V;
                Player.CharacterData.觉醒经验启用.V = false;
                Player.ActiveConnection?.发送封包(new 同步补充变量
                {
                    变量类型 = 1,
                    变量索引 = 50,
                    对象编号 = Player.ObjectId,
                    变量内容 = 3616
                });
            }

            Player.CharacterData.觉醒经验.V += Amount;

            Player.ActiveConnection?.发送封包(new 角色经验变动
            {
                经验增加 = 0,
                今日增加 = 0,
                经验上限 = 10000000,
                DoubleExp = Player.DoubleExp,
                CurrentExp = Player.CurrentExp,
                升级所需 = Player.MaxExperience,
                GainAwakeningExp = Amount,
                MaxAwakeningExp = Config.MaxAwakeningExp
            });
        }
    }
}
