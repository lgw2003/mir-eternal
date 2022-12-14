﻿using System;
using System.Collections.Generic;
using System.IO;
using GameServer.Enums;
using GameServer.Templates;

namespace GameServer.Data
{

    public class ItemData : GameData
    {

        public 游戏物品 物品模板
        {
            get
            {
                return 对应模板.V;
            }
        }

        public ItemsForSale 出售类型
        {
            get
            {
                return 物品模板.商店类型;
            }
        }


        public ItemType 物品类型
        {
            get
            {
                return 物品模板.物品分类;
            }
        }


        public PersistentItemType PersistType
        {
            get
            {
                return 物品模板.持久类型;
            }
        }

        public int? UnpackItemId
        {
            get
            {
                return 物品模板.解包物品编号;

            }
        }

        public GameObjectRace NeedRace
        {
            get
            {
                return 物品模板.需要职业;
            }
        }


        public GameObjectGender NeedGender
        {
            get
            {
                return 物品模板.需要性别;
            }
        }


        public string Name
        {
            get
            {
                return 物品模板.物品名字;
            }
        }


        public int NeedLevel
        {
            get
            {
                return 物品模板.需要等级;
            }
        }


        public int Id
        {
            get
            {
                return 对应模板.V.物品编号;
            }
        }


        public int Weight
        {
            get
            {
                if (PersistType != PersistentItemType.堆叠)
                {
                    return 物品模板.物品重量;
                }
                return 当前持久.V * 物品模板.物品重量;
            }
        }


        public int SalePrice
        {
            get
            {
                switch (对应模板.V.持久类型)
                {
                    default:
                        return 0;
                    case PersistentItemType.无:
                        return 1;
                    case PersistentItemType.装备:
                        {
                            EquipmentData EquipmentData2 = this as EquipmentData;
                            装备物品 obj = 对应模板.V as 装备物品;
                            int v3 = EquipmentData2.当前持久.V;
                            int num2 = obj.物品持久 * 1000;
                            int num3 = obj.出售价格;
                            int num4 = Math.Max((sbyte)0, EquipmentData2.Luck.V);
                            int num5 = EquipmentData2.升级Attack.V * 100 + EquipmentData2.升级Magic.V * 100 + EquipmentData2.升级Taoism.V * 100 + EquipmentData2.升级Needle.V * 100 + EquipmentData2.升级Archery.V * 100;
                            int num6 = 0;
                            foreach (铭文技能 value in EquipmentData2.铭文技能.Values)
                            {
                                if (value != null)
                                {
                                    num6++;
                                }
                            }
                            int num7 = 0;
                            foreach (随机属性 item in EquipmentData2.随机Stat)
                            {
                                num7 += item.战力加成 * 100;
                            }
                            int num8 = 0;
                            using (IEnumerator<游戏物品> enumerator3 = EquipmentData2.镶嵌灵石.Values.GetEnumerator())
                            {
                                while (enumerator3.MoveNext())
                                {
                                    switch (enumerator3.Current.物品名字)
                                    {
                                        case "驭朱灵石8级":
                                        case "精绿灵石8级":
                                        case "韧紫灵石8级":
                                        case "抵御幻彩灵石8级":
                                        case "进击幻彩灵石8级":
                                        case "盈绿灵石8级":
                                        case "狂热幻彩灵石8级":
                                        case "透蓝灵石8级":
                                        case "守阳灵石8级":
                                        case "新阳灵石8级":
                                        case "命朱灵石8级":
                                        case "蔚蓝灵石8级":
                                        case "赤褐灵石8级":
                                        case "橙黄灵石8级":
                                        case "纯紫灵石8级":
                                        case "深灰灵石8级":
                                            num8 += 8000;
                                            break;
                                        case "精绿灵石5级":
                                        case "新阳灵石5级":
                                        case "命朱灵石5级":
                                        case "蔚蓝灵石5级":
                                        case "橙黄灵石5级":
                                        case "进击幻彩灵石5级":
                                        case "深灰灵石5级":
                                        case "盈绿灵石5级":
                                        case "透蓝灵石5级":
                                        case "韧紫灵石5级":
                                        case "抵御幻彩灵石5级":
                                        case "驭朱灵石5级":
                                        case "赤褐灵石5级":
                                        case "守阳灵石5级":
                                        case "狂热幻彩灵石5级":
                                        case "纯紫灵石5级":
                                            num8 += 5000;
                                            break;
                                        case "精绿灵石2级":
                                        case "蔚蓝灵石2级":
                                        case "驭朱灵石2级":
                                        case "橙黄灵石2级":
                                        case "守阳灵石2级":
                                        case "纯紫灵石2级":
                                        case "透蓝灵石2级":
                                        case "抵御幻彩灵石2级":
                                        case "命朱灵石2级":
                                        case "深灰灵石2级":
                                        case "赤褐灵石2级":
                                        case "新阳灵石2级":
                                        case "进击幻彩灵石2级":
                                        case "狂热幻彩灵石2级":
                                        case "盈绿灵石2级":
                                        case "韧紫灵石2级":
                                            num8 += 2000;
                                            break;
                                        case "抵御幻彩灵石7级":
                                        case "命朱灵石7级":
                                        case "赤褐灵石7级":
                                        case "狂热幻彩灵石7级":
                                        case "精绿灵石7级":
                                        case "纯紫灵石7级":
                                        case "韧紫灵石7级":
                                        case "驭朱灵石7级":
                                        case "深灰灵石7级":
                                        case "盈绿灵石7级":
                                        case "新阳灵石7级":
                                        case "蔚蓝灵石7级":
                                        case "橙黄灵石7级":
                                        case "守阳灵石7级":
                                        case "进击幻彩灵石7级":
                                        case "透蓝灵石7级":
                                            num8 += 7000;
                                            break;
                                        case "精绿灵石9级":
                                        case "驭朱灵石9级":
                                        case "蔚蓝灵石9级":
                                        case "橙黄灵石9级":
                                        case "抵御幻彩灵石9级":
                                        case "透蓝灵石9级":
                                        case "纯紫灵石9级":
                                        case "命朱灵石9级":
                                        case "赤褐灵石9级":
                                        case "深灰灵石9级":
                                        case "守阳灵石9级":
                                        case "新阳灵石9级":
                                        case "盈绿灵石9级":
                                        case "进击幻彩灵石9级":
                                        case "狂热幻彩灵石9级":
                                        case "韧紫灵石9级":
                                            num8 += 9000;
                                            break;
                                        case "驭朱灵石4级":
                                        case "深灰灵石4级":
                                        case "新阳灵石4级":
                                        case "盈绿灵石4级":
                                        case "蔚蓝灵石4级":
                                        case "命朱灵石4级":
                                        case "橙黄灵石4级":
                                        case "进击幻彩灵石4级":
                                        case "抵御幻彩灵石4级":
                                        case "透蓝灵石4级":
                                        case "守阳灵石4级":
                                        case "精绿灵石4级":
                                        case "赤褐灵石4级":
                                        case "纯紫灵石4级":
                                        case "韧紫灵石4级":
                                        case "狂热幻彩灵石4级":
                                            num8 += 4000;
                                            break;
                                        case "透蓝灵石6级":
                                        case "抵御幻彩灵石6级":
                                        case "命朱灵石6级":
                                        case "盈绿灵石6级":
                                        case "深灰灵石6级":
                                        case "蔚蓝灵石6级":
                                        case "进击幻彩灵石6级":
                                        case "橙黄灵石6级":
                                        case "赤褐灵石6级":
                                        case "驭朱灵石6级":
                                        case "精绿灵石6级":
                                        case "新阳灵石6级":
                                        case "韧紫灵石6级":
                                        case "守阳灵石6级":
                                        case "纯紫灵石6级":
                                        case "狂热幻彩灵石6级":
                                            num8 += 6000;
                                            break;
                                        case "透蓝灵石1级":
                                        case "驭朱灵石1级":
                                        case "韧紫灵石1级":
                                        case "守阳灵石1级":
                                        case "赤褐灵石1级":
                                        case "纯紫灵石1级":
                                        case "狂热幻彩灵石1级":
                                        case "精绿灵石1级":
                                        case "新阳灵石1级":
                                        case "盈绿灵石1级":
                                        case "蔚蓝灵石1级":
                                        case "橙黄灵石1级":
                                        case "深灰灵石1级":
                                        case "命朱灵石1级":
                                        case "进击幻彩灵石1级":
                                        case "抵御幻彩灵石1级":
                                            num8 += 1000;
                                            break;
                                        case "蔚蓝灵石10级":
                                        case "狂热幻彩灵石10级":
                                        case "精绿灵石10级":
                                        case "透蓝灵石10级":
                                        case "橙黄灵石10级":
                                        case "抵御幻彩灵石10级":
                                        case "进击幻彩灵石10级":
                                        case "命朱灵石10级":
                                        case "守阳灵石10级":
                                        case "赤褐灵石10级":
                                        case "盈绿灵石10级":
                                        case "深灰灵石10级":
                                        case "韧紫灵石10级":
                                        case "纯紫灵石10级":
                                        case "新阳灵石10级":
                                        case "驭朱灵石10级":
                                            num8 += 10000;
                                            break;
                                        case "驭朱灵石3级":
                                        case "韧紫灵石3级":
                                        case "精绿灵石3级":
                                        case "新阳灵石3级":
                                        case "守阳灵石3级":
                                        case "盈绿灵石3级":
                                        case "蔚蓝灵石3级":
                                        case "命朱灵石3级":
                                        case "橙黄灵石3级":
                                        case "进击幻彩灵石3级":
                                        case "抵御幻彩灵石3级":
                                        case "透蓝灵石3级":
                                        case "赤褐灵石3级":
                                        case "深灰灵石3级":
                                        case "狂热幻彩灵石3级":
                                        case "纯紫灵石3级":
                                            num8 += 3000;
                                            break;
                                    }
                                }
                            }
                            int num9 = num3 + num4 + num5 + num6 + num7 + num8;
                            decimal num10 = (decimal)v3 / (decimal)num2 * 0.9m * (decimal)num9;
                            decimal num11 = (decimal)num9 * 0.1m;
                            return (int)(num10 + num11);
                        }
                    case PersistentItemType.消耗:
                        {
                            int v2 = 当前持久.V;
                            int MaxDurability = 对应模板.V.物品持久;
                            int num = 对应模板.V.出售价格;
                            return (int)((decimal)v2 / (decimal)MaxDurability * (decimal)num);
                        }
                    case PersistentItemType.堆叠:
                        {
                            int v = 当前持久.V;
                            return 对应模板.V.出售价格 * v;
                        }
                    case PersistentItemType.回复:
                        return 1;
                    case PersistentItemType.容器:
                        return 对应模板.V.出售价格;
                    case PersistentItemType.纯度:
                        return 对应模板.V.出售价格;
                }
            }
        }


        public int 堆叠上限
        {
            get
            {
                return 对应模板.V.物品持久;
            }
        }


        public int 默认持久
        {
            get
            {
                if (PersistType != PersistentItemType.装备)
                {
                    return 对应模板.V.物品持久;
                }
                return 对应模板.V.物品持久 * 1000;
            }
        }


        public byte 当前位置
        {
            get
            {
                return 物品位置.V;
            }
            set
            {
                物品位置.V = value;
            }
        }


        public bool IsBound
        {
            get
            {
                return 物品模板.是否绑定;
            }
        }

        public bool CanSold
        {
            get
            {
                return 物品模板.能否出售;
            }
        }


        public bool 能否堆叠
        {
            get
            {
                return 对应模板.V.持久类型 == PersistentItemType.堆叠;
            }
        }


        public bool CanDrop
        {
            get
            {
                return 物品模板.能否掉落;
            }
        }


        public ushort SkillId
        {
            get
            {
                return 物品模板.附加技能;
            }
        }


        public byte GroupId
        {
            get
            {
                return 物品模板.物品分组;
            }
        }


        public int GroupCooling
        {
            get
            {
                return 物品模板.分组冷却;
            }
        }


        public int Cooldown
        {
            get
            {
                return 物品模板.冷却时间;
            }
        }

        public ItemData() { }

        public ItemData(游戏物品 item, CharacterData character, byte 容器, byte position, int durability)
        {
            对应模板.V = item;
            生成来源.V = character;
            物品容器.V = 容器;
            物品位置.V = position;
            生成时间.V = MainProcess.CurrentTime;
            最大持久.V = 物品模板.物品持久;
            当前持久.V = Math.Min(durability, 最大持久.V);

            var activeQuests = character.GetInProgressQuests();
            foreach (var quest in activeQuests)
            {
                var missions = quest.GetMissionsOfType(Models.Enums.QuestMissionType.获取物品);
                var updated = false;
                foreach (var mission in missions)
                {
                    if (mission.CompletedDate.V != DateTime.MinValue) continue;
                    if (mission.Info.V.编号 != item.物品编号) continue;
                    mission.Count.V = (byte)(mission.Count.V + 1);
                    updated = true;
                }
                if (updated) character.ActiveConnection?.玩家实例.UpdateQuestProgress(quest);
            }

            GameDataGateway.物品数据表.AddData(this, true);
        }


        public override string ToString()
        {
            return Name;
        }


        public virtual byte[] 字节描述()
        {
            byte[] result;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
                {
                    binaryWriter.Write(数据版本);
                    BinaryWriter binaryWriter2 = binaryWriter;
                    CharacterData v = 生成来源.V;
                    binaryWriter2.Write((v != null) ? v.Index.V : 0);
                    binaryWriter.Write(ComputingClass.TimeShift(生成时间.V));
                    binaryWriter.Write(对应模板.V.物品编号);
                    binaryWriter.Write(物品容器.V);
                    binaryWriter.Write(物品位置.V);
                    binaryWriter.Write(当前持久.V);
                    binaryWriter.Write(最大持久.V);
                    binaryWriter.Write((byte)(IsBound ? 10 : 0));
                    binaryWriter.Write((ushort)0);
                    binaryWriter.Write(0);
                    result = memoryStream.ToArray();
                }
            }
            return result;
        }


        public virtual byte[] 字节描述(int 数量)
        {
            byte[] result;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
                {
                    binaryWriter.Write(数据版本);
                    BinaryWriter binaryWriter2 = binaryWriter;
                    CharacterData v = 生成来源.V;
                    binaryWriter2.Write((v != null) ? v.Index.V : 0);
                    binaryWriter.Write(ComputingClass.TimeShift(生成时间.V));
                    binaryWriter.Write(对应模板.V.物品编号);
                    binaryWriter.Write(物品容器.V);
                    binaryWriter.Write(物品位置.V);
                    binaryWriter.Write(数量);
                    binaryWriter.Write(最大持久.V);
                    binaryWriter.Write((byte)(IsBound ? 10 : 0));
                    binaryWriter.Write((ushort)0);
                    binaryWriter.Write(0);
                    result = memoryStream.ToArray();
                }
            }
            return result;
        }


        static ItemData()
        {

            数据版本 = 14;
        }


        public static byte 数据版本;


        public readonly DataMonitor<游戏物品> 对应模板;


        public readonly DataMonitor<DateTime> 生成时间;


        public readonly DataMonitor<CharacterData> 生成来源;


        public readonly DataMonitor<int> 当前持久;


        public readonly DataMonitor<int> 最大持久;


        public readonly DataMonitor<byte> 物品容器;


        public readonly DataMonitor<byte> 物品位置;


        public int PurchaseId;

        public int GetProp(ItemProperty property, int defaultValue = 0)
        {
            return 物品模板.物品属性.TryGetValue(property, out int value)
                ? value
                : defaultValue;
        }

        public bool HasProp(ItemProperty property)
        {
            return 物品模板.物品属性.ContainsKey(property);
        }
    }
}
