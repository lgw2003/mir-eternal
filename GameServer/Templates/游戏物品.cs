using GameServer.Enums;
using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Templates
{
    /// <summary>
    /// 游戏物品
    /// </summary>
    public class 游戏物品
    {
        public static Dictionary<int, 游戏物品> DataSheet;
        public static Dictionary<string, 游戏物品> DataSheetByName;

        public string 物品名字;
        public int 物品编号;
        public int 物品持久;
        public int 物品重量;
        public int 物品等级;
        public int 需要等级;
        public int 冷却时间;
        public byte 物品分组;
        public int 分组冷却;
        public int 出售价格;
        public ushort 附加技能;
        public bool 是否绑定;
        public bool 能否分解;
        public bool 能否掉落;
        public bool 能否出售;
        public bool 贵重物品;
        public bool 资源物品;
        public int? 解包物品编号;
        public List<GameItemTreasure> 宝盒物品 = new List<GameItemTreasure>();

        public ItemType 物品分类;
        public GameObjectRace 需要职业;
        public GameObjectGender 需要性别;
        public PersistentItemType 持久类型;
        public ItemsForSale 商店类型;

        public IDictionary<ItemProperty, int> 物品属性 = new Dictionary<ItemProperty, int>();

        public static 游戏物品 GetItem(int id)
        {
            if (!DataSheet.TryGetValue(id, out 游戏物品 result))
            {
                return null;
            }
            return result;
        }


        public static 游戏物品 GetItem(string name)
        {
            if (!DataSheetByName.TryGetValue(name, out 游戏物品 result))
                return null;
            return result;
        }


        public static void LoadData()
        {
            DataSheet = new Dictionary<int, 游戏物品>();
            DataSheetByName = new Dictionary<string, 游戏物品>();

            string text = Config.GameDataPath + "\\System\\物品数据\\普通物品\\";
            if (Directory.Exists(text))
            {
                var array = Serializer.Deserialize<游戏物品>(text);
                for (int i = 0; i < array.Length; i++)
                {
                    游戏物品 gameItem = array[i] as 游戏物品;
                    DataSheet.Add(gameItem.物品编号, gameItem);
                    DataSheetByName.Add(gameItem.物品名字, gameItem);
                }
            }

            text = Config.GameDataPath + "\\System\\物品数据\\装备物品\\";
            if (Directory.Exists(text))
            {
                var array = Serializer.Deserialize<EquipmentItem>(text);
                for (int i = 0; i < array.Length; i++)
                {
                    EquipmentItem gameItem = array[i] as EquipmentItem;
                    DataSheet.Add(gameItem.物品编号, gameItem);
                    DataSheetByName.Add(gameItem.物品名字, gameItem);
                }
            }
        }
    }
}
