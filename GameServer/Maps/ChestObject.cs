﻿using GameServer.Data;
using GameServer.Networking;
using GameServer.Templates;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Maps
{
    public class ChestPlayerOpener
    {
        public PlayerObject Player;
        public DateTime EndOpensTime;
        public DateTime NextAppearTime;
        public bool OpenCompleted;
    }

    public class ChestObject : MapObject
    {
        private List<ChestPlayerOpener> _openers = new List<ChestPlayerOpener>();

        public override GameObjectType ObjectType => GameObjectType.宝盒;
        public override ObjectSize ObjectSize => ObjectSize.单体1x1;
        public 宝箱数据 Template { get; set; }

        public ChestObject(宝箱数据 template, MapInstance map, GameDirection direction, Point position)
        {
            Template = template;
            this.CurrentMap = map;
            this.CurrentDirection = direction;
            this.CurrentPosition = position;
            this.ObjectId = ++MapGatewayProcess.ObjectId;
            MapGatewayProcess.AddObject(this);
            RefreshStats();
            SecondaryObject = false;
            Died = false;
            Blocking = false;
            BindGrid();
            更新邻居时处理();
        }

        public void ActivateObject()
        {
            if (!this.ActiveObject)
            {
                this.ActiveObject = true;
                MapGatewayProcess.ActivateObject(this);
            }
        }

        public override void Process()
        {
            base.Process();

            if (_openers.Count == 0) return;

            var newList = _openers.ToArray();

            foreach (var opener in newList)
            {
                if (!opener.OpenCompleted && MainProcess.CurrentTime >= opener.EndOpensTime)
                {
                    opener.Player.ActiveConnection.发送封包(new 结束操作道具
                    {
                        PlayerId = opener.Player.ObjectId,
                        ObjectId = ObjectId
                    });

                    var items = opener.Player.FilterItemTreasures(Template.物品);

                    foreach (var item in items)
                    {
                        if (!游戏物品.DataSheetByName.TryGetValue(item.物品名字, out var itemTemplate))
                            continue;

                        new ItemObject(itemTemplate, null, CurrentMap, CurrentPosition, new HashSet<CharacterData> { opener.Player.CharacterData }, 堆叠数量: 1, dropperObject: this);
                    }

                    opener.Player.ActiveConnection.发送封包(new 同步道具次数
                    {
                        PlayerId = opener.Player.ObjectId,
                        ObjectId = ObjectId
                    });

                    opener.Player.ActiveConnection.发送封包(new 对象离开视野
                    {
                        对象编号 = ObjectId,
                        消失方式 = 1
                    });

                    opener.OpenCompleted = true;
                    opener.NextAppearTime = MainProcess.CurrentTime.AddMinutes(1);
                }
                else if (opener.OpenCompleted && MainProcess.CurrentTime >= opener.NextAppearTime)
                {
                    _openers.Remove(opener);
                }
            }
        }

        public bool IsAlredyOpened(PlayerObject player)
        {
            return !_openers.Any(x => x.Player == player);
        }

        public void Open(PlayerObject player)
        {
            _openers.Add(new ChestPlayerOpener
            {
                Player = player,
                EndOpensTime = MainProcess.CurrentTime.AddSeconds(1.6)
            });

            player.ActiveConnection.发送封包(new 开始操作道具
            {
                PlayerId = player.ObjectId,
                ObjectId = ObjectId,
                Duration = 16
            });
        }

    }
}
