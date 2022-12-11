using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Templates
{
    /// <summary>
    /// 游戏地图
    /// </summary>
    public sealed class 游戏地图
    {
        public static Dictionary<byte, 游戏地图> DataSheet;

        public byte 地图编号;
        public string 地图名字;
        public string 地图别名;
        public string 地形文件;
        public int 限制人数;
        public byte 限制等级;
        public byte 分线数量;
        public bool 下线传送;
        public byte 传送地图;
        public bool 副本地图;

        public static void LoadData()
        {
            DataSheet = new Dictionary<byte, 游戏地图>();
            string text = Config.GameDataPath + "\\System\\游戏地图\\地图数据\\";
            if (Directory.Exists(text))
            {
                foreach (var obj in Serializer.Deserialize<游戏地图>(text))
                    DataSheet.Add(obj.地图编号, obj);
            }
        }

        public override string ToString()
        {
            return 地图名字;
        }
    }
}
