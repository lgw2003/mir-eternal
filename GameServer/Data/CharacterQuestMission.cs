using Models;
using System;

namespace GameServer.Data
{
    /// <summary>
    /// 玩家任务安排
    /// </summary>
    public class CharacterQuestMission : GameData
    {
        public DataMonitor<CharacterQuest> 玩家任务;
        public DataMonitor<GameQuestMission> 完成条件;
        public DataMonitor<DateTime> 完成日期;
        public DataMonitor<byte> 数量;

        public static CharacterQuestMission 创建(CharacterQuest 玩家任务, GameQuestMission 完成条件)
        {
            var charConstraint = new CharacterQuestMission();
            charConstraint.玩家任务.V = 玩家任务;
            charConstraint.完成条件.V = 完成条件;
            charConstraint.数量.V = 0;

            GameDataGateway.角色执行任务数据表.AddData(charConstraint, true);

            return charConstraint;
        }
    }
}
