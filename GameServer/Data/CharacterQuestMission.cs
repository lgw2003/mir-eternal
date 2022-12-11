using Models;
using System;

namespace GameServer.Data
{
    public class CharacterQuestMission : GameData
    {
        public DataMonitor<CharacterQuest> CharacterQuest;
        public DataMonitor<GameQuestMission> Info;
        public DataMonitor<DateTime> CompletedDate;
        public DataMonitor<byte> Count;

        public static CharacterQuestMission Create(CharacterQuest characterQuest, GameQuestMission mission)
        {
            var charConstraint = new CharacterQuestMission();
            charConstraint.CharacterQuest.V = characterQuest;
            charConstraint.Info.V = mission;
            charConstraint.Count.V = 0;

            GameDataGateway.角色执行任务数据表.AddData(charConstraint, true);

            return charConstraint;
        }
    }
}
