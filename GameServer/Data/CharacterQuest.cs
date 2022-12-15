using GameServer.Templates;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Data
{
    /// <summary>
    /// 玩家任务
    /// </summary>
    public class CharacterQuest : GameData
    {
        public DataMonitor<CharacterData> 玩家数据;
        public readonly DataMonitor<游戏任务> 任务信息;
        public readonly DataMonitor<DateTime> 开始时间;
        public readonly DataMonitor<DateTime> 完成时间;
        public readonly HashMonitor<CharacterQuestMission> 玩家任务要求;

        public bool 已经完成 => 玩家任务要求.All(x => x.完成日期.V != DateTime.MinValue);

        public static CharacterQuest 创建(CharacterData 玩家, 游戏任务 任务)
        {
            var charQuest = new CharacterQuest();

            charQuest.玩家数据.V = 玩家;
            charQuest.任务信息.V = 任务;
            charQuest.开始时间.V = MainProcess.CurrentTime;

            foreach (var mission in 任务.执行任务)
            {
                if (mission.职业 != null && mission.职业.Value != 玩家.角色职业.V) continue;

                charQuest.玩家任务要求.Add(CharacterQuestMission.创建(charQuest, mission));
            }

            GameDataGateway.角色任务数据表.AddData(charQuest, true);

            return charQuest;
        }

        public override void 删除数据()
        {
            foreach (var constraint in 玩家任务要求)
                constraint.删除数据();

            base.删除数据();
        }

        public CharacterQuestMission[] 根据类型获取任务要求(QuestMissionType type)
        {
            return 玩家任务要求
                .Where(x => x.完成条件.V.类型 == type)
                .ToArray();
        }
    }
}
