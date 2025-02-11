﻿using GameServer.Data;
using GameServer.Maps;
using GameServer.Networking;
using GameServer.Templates;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.GMCommands
{
    public class Move : GMCommand
    {
        public override ExecutionWay ExecutionWay => ExecutionWay.优先后台执行;

        public override void Execute()
        {
            if (!GameDataGateway.角色数据表.Keyword.TryGetValue(Character, out GameData gd))
            {
                MainForm.添加命令日志($"<= @Move Command execution failed, character {Character} does not exist");
                return;
            }

            if (!游戏地图.DataSheet.TryGetValue(MapId, out 游戏地图 map))
            {
                MainForm.添加命令日志($"<= @Move Command execution failed, map {MapId} does not exist");
                return;
            }

            var characterData = gd as CharacterData;

            var player = characterData?.网络连接?.玩家实例;

            if (player == null)
            {
                MainForm.添加命令日志($"<= @Move Command execution failed, player {Character} not connected");
                return;
            }

            var mapInstance = MapGatewayProcess.GetMapInstance(map.地图编号);
            var mapArea = mapInstance.传送区域 ?? mapInstance.地图区域.FirstOrDefault();

            var location = MapX != null && MapY != null
                ? new Point(MapX.Value, MapY.Value)
                : mapArea?.RandomCoords ?? Point.Empty;

            if (location.IsEmpty)
            {
                for (var x = 1; x < mapInstance.MapSize.X; x++)
                    for (var y = 1; y < mapInstance.MapSize.Y; y++)
                        if (mapInstance.CanPass(new Point(x, y)))
                        {
                            location = new Point(x, y);
                            break;
                        }
            }

            player.玩家切换地图(mapInstance, mapArea?.区域类型 ?? AreaType.未知区域, location);
        }

        [Field(0)]
        public string Character;

        [Field(1)]
        public byte MapId;

        [Field(2, IsOptional = true)]
        public int? MapX;

        [Field(3, IsOptional = true)]
        public int? MapY;
    }
}
