using Models.Enums;

namespace Models
{
    /// <summary>
    /// 接受任务条件类
    /// </summary>
    public class GameQuestConstraint
    {
        public QuestAcceptConstraint 类型 { get; set; }
        public int 数值 { get; set; }
    }
}
