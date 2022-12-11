using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Templates
{
    /// <summary>
    /// 宝箱数据
    /// </summary>
    public class 宝箱数据
    {
        public static Dictionary<int, 宝箱数据> DataSheet;

        public int 宝箱编号 { get; set; }
        public string 宝箱名字 { get; set; }
        public GameItemTreasure[] 物品 { get; set; }


        public static void LoadData()
        {
            string text = Config.GameDataPath + "\\System\\Npc数据\\宝箱数据\\";

            if (Directory.Exists(text))
                DataSheet = Serializer.Deserialize<宝箱数据>(text).ToDictionary(x => x.宝箱编号);
            else
                DataSheet = new Dictionary<int, 宝箱数据>();
        }
    }
}
