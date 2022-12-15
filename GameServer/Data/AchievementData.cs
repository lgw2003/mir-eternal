using GameServer.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Data
{
    /// <summary>
    /// 成就数据
    /// </summary>
    public class AchievementData : GameData
    {
        public readonly DataMonitor<ushort> 成就编号;

        public readonly DataMonitor<DateTime> CompletedAt;

        public readonly DataMonitor<DateTime> ReceivedAt;

        public readonly DataMonitor<CharacterData> Character;
        public 游戏成就 Info => 游戏成就.DataSheet.TryGetValue(成就编号.V, out var achievementInfo) ? achievementInfo : null;
    }
}
