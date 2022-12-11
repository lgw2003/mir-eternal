using GameServer.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Data
{
    public class AchievementData : GameData
    {
        public readonly DataMonitor<ushort> AchievementId;

        public readonly DataMonitor<DateTime> CompletedAt;

        public readonly DataMonitor<DateTime> ReceivedAt;

        public readonly DataMonitor<CharacterData> Character;
        public 游戏成就 Info => 游戏成就.DataSheet.TryGetValue(AchievementId.V, out var achievementInfo) ? achievementInfo : null;
    }
}
