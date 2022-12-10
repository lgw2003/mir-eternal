using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Templates
{
    public class GameItemTreasure
    {
        public string 物品名字 { get; set; }
        public GameObjectRace? 需要职业 { get; set; } = null;
        public int? 概率 { get; set; } = null;
    }
}
