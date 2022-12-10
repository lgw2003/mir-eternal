using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GameServer.Templates
{
    /// <summary>
    /// 装备属性
    /// </summary>
    public sealed partial class EquipmentStats
    {
        public static Dictionary<byte, EquipmentStats> DataSheet;
        public static Dictionary<byte, RandomStats[]> 概率表;

        public ItemType 装备部位;
        public float 极品概率;
        public int 单条概率;
        public int 两条概率;
        public StatsDetail[] 属性列表;

        public static List<RandomStats> GenerateStats(ItemType Type, bool reforgedEquipment = false)
        {
            EquipmentStats stats;
            if (DataSheet.TryGetValue((byte)Type, out stats) && 概率表.TryGetValue((byte)Type, out RandomStats[] array) && array.Length != 0 && (reforgedEquipment || ComputingClass.CheckProbability(stats.极品概率)))
            {
                int num = MainProcess.RandomNumber.Next(100);
                Dictionary<GameObjectStats, RandomStats> dictionary = new Dictionary<GameObjectStats, RandomStats>();
                int num2 = (num < stats.单条概率) ? 1 : ((num < stats.两条概率) ? 2 : 3);
                for (int i = 0; i < num2; i++)
                {
                    RandomStats 随机Stat = array[MainProcess.RandomNumber.Next(array.Length)];
                    if (!dictionary.ContainsKey(随机Stat.对应属性))
                        dictionary[随机Stat.对应属性] = 随机Stat;
                }
                return dictionary.Values.ToList();
            }
            return new List<RandomStats>();
        }

        public static void LoadData()
        {
            DataSheet = new Dictionary<byte, EquipmentStats>();
            var text = Config.GameDataPath + "\\System\\物品数据\\装备属性\\";

            if (Directory.Exists(text))
            {
                foreach (var obj in Serializer.Deserialize<EquipmentStats>(text))
                    DataSheet.Add((byte)obj.装备部位, obj);
            }

            概率表 = new Dictionary<byte, RandomStats[]>();

            foreach (KeyValuePair<byte, EquipmentStats> kvp in DataSheet)
            {
                var list = new List<RandomStats>();
                
                foreach (StatsDetail Stat详情 in kvp.Value.属性列表)
                    if (RandomStats.DataSheet.TryGetValue(Stat详情.属性编号, out RandomStats item))
                        for (int j = 0; j < Stat详情.属性概率; j++)
                            list.Add(item);

                概率表[kvp.Key] = list.ToArray();
            }
        }
    }
}
