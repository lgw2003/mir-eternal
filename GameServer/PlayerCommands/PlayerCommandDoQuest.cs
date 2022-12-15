using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.PlayerCommands
{
    public class PlayerCommandDoQuest : PlayerCommand
    {
        public override void Execute()
        {
            var quests = Player.CharacterData.获取正在进行的任务();

            foreach (var quest in quests)
            {
                foreach (var mission in quest.玩家任务要求)
                {
                    if (mission.完成日期.V != DateTime.MinValue)
                        continue;

                    if (mission.完成条件.V.类型 == Models.Enums.QuestMissionType.获取物品 || mission.完成条件.V.类型 == Models.Enums.QuestMissionType.杀死怪物)
                        mission.数量.V = (byte)mission.完成条件.V.数量;

                    mission.完成日期.V = MainProcess.CurrentTime;
                }

                Player.完成任务(quest.任务信息.V.编号);
            }
        }
    }
}
