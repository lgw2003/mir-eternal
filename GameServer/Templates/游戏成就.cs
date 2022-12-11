using Models.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Templates
{
    public class GameAchievementCondition
    {
        public string 描述 { get; set; }
        public string 类型 { get; set; }
        public Dictionary<string, object> 道具 { get; set; }
    }

    public class GameAchievementReward
    {
        public QuestRewardType 类型 { get; set; }
        public int 编号 { get; set; }
    }
    /// <summary>
    /// 游戏成就
    /// </summary>
    public class 游戏成就
    {
        public static Dictionary<ushort, 游戏成就> DataSheet;

        public ushort 编号 { get; set; }
        public string 名字 { get; set; }
        public string 描述 { get; set; }
        public int 基本类型 { get; set; }
        public int 子类型 { get; set; }
        public QuestResetType 重置类型 { get; set; }
        public int 成就点数 { get; set; }
        public List<int> PreAchivements { get; set; } = new List<int>();
        public List<GameAchievementCondition> 条件 { get; set; } = new List<GameAchievementCondition>();
        public List<GameAchievementReward> 奖励 { get; set; } = new List<GameAchievementReward>();


        public static void LoadData()
        {
            string text = Config.GameDataPath + "\\System\\成就数据\\";

            if (Directory.Exists(text))
                DataSheet = Serializer.Deserialize<游戏成就>(text).ToDictionary(x => x.编号);
            else
                DataSheet = new Dictionary<ushort, 游戏成就>();
        }
    }
}
