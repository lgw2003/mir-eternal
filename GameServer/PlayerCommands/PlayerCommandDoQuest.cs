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
            var quests = Player.CharacterData.GetInProgressQuests();

            foreach (var quest in quests)
            {
                foreach (var mission in quest.Missions)
                {
                    if (mission.CompletedDate.V != DateTime.MinValue)
                        continue;

                    if (mission.Info.V.类型 == Models.Enums.QuestMissionType.获取物品 || mission.Info.V.类型 == Models.Enums.QuestMissionType.杀死怪物)
                        mission.Count.V = (byte)mission.Info.V.数量;

                    mission.CompletedDate.V = MainProcess.CurrentTime;
                }

                Player.CompleteQuest(quest.Info.V.编号);
            }
        }
    }
}
