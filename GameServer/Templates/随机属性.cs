using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Templates
{
    /// <summary>
    /// 随机属性
    /// </summary>
    public sealed class 随机属性
    {
        public static Dictionary<int, 随机属性> DataSheet;

        public GameObjectStats 对应属性;
        public int 属性数值;
        public int 属性编号;
        public int 战力加成;
        public string 属性描述;

        public static void LoadData()
        {
            DataSheet = new Dictionary<int, 随机属性>();
            var text = Config.GameDataPath + "\\System\\物品数据\\随机属性\\";

            if (Directory.Exists(text))
            {
                foreach (var obj in Serializer.Deserialize<随机属性>(text))
                    DataSheet.Add(obj.属性编号, obj);

            }
        }
    }
}
