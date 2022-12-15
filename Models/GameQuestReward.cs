using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 任务奖励类
    /// </summary>
    public class GameQuestReward
    {
        public QuestRewardType 类型 { get; set; }
        public int 编号 { get; set; }
        public int 数量 { get; set; }
        public bool Bind { get; set; }
    }
}
