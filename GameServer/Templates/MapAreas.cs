using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace GameServer.Templates
{
    /// <summary>
    /// 地图区域
    /// </summary>
    public class MapAreas
    {
        public static List<MapAreas> DataSheet;

        public byte 所处地图;
        public string 所处地名;
        public Point 所处坐标;
        public string 区域名字;
        public int 区域半径;
        public AreaType 区域类型;
        public HashSet<Point> 范围坐标;

        private List<Point> _范围坐标列表;

        public static void LoadData()
        {
            DataSheet = new List<MapAreas>();
            string text = Config.GameDataPath + "\\System\\游戏地图\\地图区域\\";
            if (Directory.Exists(text))
            {
                foreach (object obj in Serializer.Deserialize<MapAreas>(text))
                {
                    DataSheet.Add((MapAreas)obj);
                }
            }
        }

        /// <summary>
        /// 随机坐标
        /// </summary>
        public Point RandomCoords
        {
            get
            {
                return RangeCoordsList[MainProcess.RandomNumber.Next(范围坐标.Count)];
            }
        }
        /// <summary>
        /// 范围坐标列表
        /// </summary>
        public List<Point> RangeCoordsList
        {
            get
            {
                if (_范围坐标列表 == null)
                    _范围坐标列表 = 范围坐标.ToList();
                return _范围坐标列表;
            }
        }
    }
}
