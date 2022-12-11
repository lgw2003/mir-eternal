﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GameServer.Data;
using GameServer.Templates;

namespace GameServer.Maps
{

    public sealed class ItemObject : MapObject
    {

        public override MapInstance CurrentMap
        {
            get
            {
                return base.CurrentMap;
            }
            set
            {
                if (this.CurrentMap != value)
                {
                    MapInstance CurrentMap = base.CurrentMap;
                    if (CurrentMap != null)
                    {
                        CurrentMap.移除对象(this);
                    }
                    base.CurrentMap = value;
                    base.CurrentMap.添加对象(this);
                }
            }
        }


        public override int ProcessInterval
        {
            get
            {
                return 100;
            }
        }


        public override bool Died
        {
            get
            {
                return false;
            }
        }


        public override bool Blocking
        {
            get
            {
                return false;
            }
        }


        public override bool CanBeHit
        {
            get
            {
                return false;
            }
        }


        public override GameObjectType ObjectType
        {
            get
            {
                return GameObjectType.物品;
            }
        }


        public override ObjectSize ObjectSize
        {
            get
            {
                return ObjectSize.单体1x1;
            }
        }


        public PersistentItemType PersistType
        {
            get
            {
                return this.物品模板.持久类型;
            }
        }


        public int 默认持久
        {
            get
            {
                return this.物品模板.物品持久;
            }
        }


        public int Id
        {
            get
            {
                游戏物品 游戏物品 = this.物品模板;
                if (游戏物品 == null)
                {
                    return 0;
                }
                return 游戏物品.物品编号;
            }
        }


        public int Weight
        {
            get
            {
                if (this.物品模板.持久类型 != PersistentItemType.堆叠)
                {
                    return this.物品模板.物品重量;
                }
                return this.物品模板.物品重量 * this.堆叠数量;
            }
        }


        public bool 允许堆叠
        {
            get
            {
                return this.物品模板.持久类型 == PersistentItemType.堆叠;
            }
        }

        public int DropperObjectId
        {
            get
            {
                return DropperObject?.ObjectId ?? ObjectId;
            }
        }

        public ItemObject(游戏物品 物品模板, ItemData ItemData, MapInstance 掉落地图, Point 掉落坐标, HashSet<CharacterData> 物品归属, int 堆叠数量 = 0, bool 物品绑定 = false, MapObject dropperObject = null)
        {
            this.DropperObject = dropperObject;
            this.物品归属 = 物品归属;
            this.物品模板 = 物品模板;
            this.ItemData = ItemData;
            this.CurrentMap = 掉落地图;
            this.ItemData = ItemData;
            this.堆叠数量 = 堆叠数量;
            this.物品绑定 = (物品模板.是否绑定 || 物品绑定);

            int num = int.MaxValue;
            for (int i = 0; i <= 120; i++)
            {
                int num2 = 0;
                Point point = ComputingClass.螺旋坐标(掉落坐标, i);
                if (!掉落地图.IsBlocked(point))
                {
                    foreach (MapObject MapObject in 掉落地图[point])
                    {
                        if (!MapObject.Died)
                        {
                            GameObjectType 对象类型 = MapObject.ObjectType;
                            switch (对象类型)
                            {
                                case GameObjectType.玩家:
                                    num2 += 10000;
                                    continue;
                                case GameObjectType.宠物:
                                case GameObjectType.怪物:
                                    break;
                                case (GameObjectType)3:
                                    continue;
                                default:
                                    if (对象类型 != GameObjectType.Npcc)
                                    {
                                        if (对象类型 != GameObjectType.物品)
                                        {
                                            continue;
                                        }
                                        num2 += 100;
                                        continue;
                                    }
                                    break;
                            }
                            num2 += 1000;
                        }
                    }
                    if (num2 == 0)
                    {
                        CurrentPosition = point;
                    IL_111:
                        this.CurrentPosition = CurrentPosition;
                        this.消失时间 = MainProcess.CurrentTime.AddMinutes((double)Config.ItemCleaningTime);
                        this.归属时间 = MainProcess.CurrentTime.AddMinutes((double)Config.ItemOwnershipTime);
                        this.ObjectId = ++MapGatewayProcess.MapInstanceId;
                        base.BindGrid();
                        base.更新邻居时处理();
                        MapGatewayProcess.AddObject(this);
                        this.SecondaryObject = true;
                        MapGatewayProcess.AddSecondaryObject(this);
                        return;
                    }
                    if (num2 < num)
                    {
                        CurrentPosition = point;
                        num = num2;
                    }
                }
            }
            //goto IL_111;
        }

        public int GetOwnerPlayerIdForDrop(PlayerObject playerAppearing)
        {
            return 物品归属 == null || 物品归属.Contains(playerAppearing.CharacterData)
                ? playerAppearing.CharacterData.CharId
                : 物品归属?.FirstOrDefault()?.CharId ?? 0;

        }

        public override void Process()
        {
            if (MainProcess.CurrentTime > this.消失时间)
            {
                this.物品消失处理();
            }
        }


        public void 物品消失处理()
        {
            ItemData ItemData = this.ItemData;
            if (ItemData != null)
            {
                ItemData.Delete();
            }
            base.Delete();
        }


        public void 物品转移处理()
        {
            base.Delete();
        }


        public ItemData ItemData;


        public 游戏物品 物品模板;


        public int 堆叠数量;


        public bool 物品绑定;


        public DateTime 消失时间;


        public DateTime 归属时间;
        public MapObject DropperObject;
        public HashSet<CharacterData> 物品归属;
    }
}
