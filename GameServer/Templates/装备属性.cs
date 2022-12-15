using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GameServer.Templates
{
    /// <summary>
    /// 装备属性
    /// </summary>
    public sealed partial class 装备属性
    {
        public static Dictionary<byte, 装备属性> DataSheet;
        public static Dictionary<byte, 随机属性[]> 概率表;

        public ItemType 装备部位;
        public float 极品概率;
        public int 单条概率;
        public int 两条概率;
        public 属性详情[] 属性列表;

        public static List<随机属性> GenerateStats(ItemType Type, bool reforgedEquipment = false)
        {
            装备属性 stats;
            if (DataSheet.TryGetValue((byte)Type, out stats) && 概率表.TryGetValue((byte)Type, out 随机属性[] array) && array.Length != 0 && (reforgedEquipment || ComputingClass.CheckProbability(stats.极品概率)))
            {
                int num = MainProcess.RandomNumber.Next(100);
                Dictionary<GameObjectStats, 随机属性> dictionary = new Dictionary<GameObjectStats, 随机属性>();
                int num2 = (num < stats.单条概率) ? 1 : ((num < stats.两条概率) ? 2 : 3);
                for (int i = 0; i < num2; i++)
                {
                    随机属性 随机Stat = array[MainProcess.RandomNumber.Next(array.Length)];
                    if (!dictionary.ContainsKey(随机Stat.对应属性))
                        dictionary[随机Stat.对应属性] = 随机Stat;
                }
                return dictionary.Values.ToList();
            }
            return new List<随机属性>();
        }

        public static void LoadData()
        {
            DataSheet = new Dictionary<byte, 装备属性>();
            var text = Config.GameDataPath + "\\System\\物品数据\\装备属性\\";

            if (Directory.Exists(text))
            {
                foreach (var obj in Serializer.Deserialize<装备属性>(text))
                    DataSheet.Add((byte)obj.装备部位, obj);
            }

            概率表 = new Dictionary<byte, 随机属性[]>();

            foreach (KeyValuePair<byte, 装备属性> kvp in DataSheet)
            {
                var list = new List<随机属性>();
                
                foreach (属性详情 Stat详情 in kvp.Value.属性列表)
                    if (随机属性.DataSheet.TryGetValue(Stat详情.属性编号, out 随机属性 item))
                        for (int j = 0; j < Stat详情.属性概率; j++)
                            list.Add(item);

                概率表[kvp.Key] = list.ToArray();
            }
        }
    }
}
