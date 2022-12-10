using Models;
using Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Templates
{
    /// <summary>
    /// 游戏任务
    /// </summary>
    public class GameQuests
    {
        public static IDictionary<int, GameQuests> DataSheet;
        public static GameQuests[] 可用任务;

        public int 编号;
        public int 章节;
        public int 阶段;
        public string 名字;
        public int 等级;
        public QuestType 类型;
        public QuestResetType 重置;
        public QuestRelationLimit 关系限制;

        public int 开始NPC地图编号;
        public int 开始NPC编号;
        public int 完成NPC编号;
        public int 连续任务编号;
        public int 最大完成数量;

        public int 重置时间;
        public bool 可否放弃;
        public bool 可否共享;
        public bool 可否发布;
        public bool 可否传送;

        public int 传送花费物品编号;
        public int 传送花费物品数值;

        public List<GameQuestReward> 固定奖励 = new List<GameQuestReward>();
        public List<GameQuestReward> 可选奖励 = new List<GameQuestReward>();
        public List<GameQuestMission> 执行任务 = new List<GameQuestMission>();
        public List<GameQuestConstraint> 限制条件 = new List<GameQuestConstraint>();

        public static void LoadData()
        {
            DataSheet = new Dictionary<int, GameQuests>();

            var quests = new List<GameQuests>();
            string text = Config.GameDataPath + "\\System\\任务数据\\";
            if (Directory.Exists(text))
            {
                foreach (GameQuests obj in Serializer.Deserialize<GameQuests>(text))
                {
                    for (var i = 0; i < obj.执行任务.Count; i++)
                    {
                        obj.执行任务[i].QuestId = obj.编号;
                        obj.执行任务[i].MissionIndex = i;
                    }
                    quests.Add(obj);
                    DataSheet.Add((obj).编号, obj);
                }
            }

            可用任务 = quests.OrderBy(x => x.编号).ToArray();
        }
    }
}
