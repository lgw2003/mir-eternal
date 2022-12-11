﻿using GameServer.Templates;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Data
{

    public class CharacterQuest : GameData
    {
        public DataMonitor<CharacterData> Character;
        public readonly DataMonitor<游戏任务> Info;
        public readonly DataMonitor<DateTime> StartDate;
        public readonly DataMonitor<DateTime> CompleteDate;
        public readonly HashMonitor<CharacterQuestMission> Missions;

        public bool IsCompleted => Missions.All(x => x.CompletedDate.V != DateTime.MinValue);

        public static CharacterQuest Create(CharacterData character, 游戏任务 gameQuest)
        {
            var charQuest = new CharacterQuest();

            charQuest.Character.V = character;
            charQuest.Info.V = gameQuest;
            charQuest.StartDate.V = MainProcess.CurrentTime;

            foreach (var mission in gameQuest.执行任务)
            {
                if (mission.职业 != null && mission.职业.Value != character.CharRace.V) continue;

                charQuest.Missions.Add(CharacterQuestMission.Create(charQuest, mission));
            }

            GameDataGateway.角色任务数据表.AddData(charQuest, true);

            return charQuest;
        }

        public override void Delete()
        {
            foreach (var constraint in Missions)
                constraint.Delete();

            base.Delete();
        }

        public CharacterQuestMission[] GetMissionsOfType(QuestMissionType type)
        {
            return Missions
                .Where(x => x.Info.V.类型 == type)
                .ToArray();
        }
    }
}
