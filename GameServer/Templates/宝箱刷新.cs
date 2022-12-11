using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Templates
{

    /// <summary>
    /// 宝箱刷新
    /// </summary>
    public class 宝箱刷新
    {
        public static HashSet<宝箱刷新> DataSheet;

        public int 宝箱编号 { get; set; }
        public int 所处地图 { get; set; }
        public Point 所处坐标 { get; set; }
        public GameDirection 所处方向 { get; set; }

        public static void LoadData()
        {
            string text = Config.GameDataPath + "\\System\\游戏地图\\宝箱刷新\\";

            if (Directory.Exists(text))
                DataSheet = new HashSet<宝箱刷新>(Serializer.Deserialize<宝箱刷新>(text));
            else
                DataSheet = new HashSet<宝箱刷新>();
        }

    }
}
