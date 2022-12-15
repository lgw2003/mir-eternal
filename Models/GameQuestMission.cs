using GameServer;
using Models.Enums;
using System.Text.Json.Serialization;

namespace Models
{
    /// <summary>
    /// 执行任务完成条件类
    /// </summary>
    public class GameQuestMission
    {
        [JsonIgnore]
        public int QuestId { get; set; }
        [JsonIgnore]
        public int MissionIndex { get; set; }

        public QuestMissionType 类型 { get; set; }
        public GameObjectRace? 职业 { get; set; } = null;
        public int 编号 { get; set; }
        public int 数量 { get; set; }
    }
}
