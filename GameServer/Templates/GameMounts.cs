using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GameServer.Templates
{
    /// <summary>
    /// 游戏坐骑
    /// </summary>
    public class GameMounts
    {
        public static IDictionary<ushort, GameMounts> DataSheet;

        public ushort 坐骑编号;
        public string 坐骑名字;
        public int AuraID;
        public short 御兽之力;
        public ushort Buff编号;
        public byte 品质;
        public byte 等级限制;
        public int 速度修改率;
        public int HitUnmountRate;      //被击中下马概率

        //其他坐骑属性等待完善

        [JsonIgnore]
        public Dictionary<GameObjectStats, int> Stats;

        public static void LoadData()
        {
            DataSheet = new Dictionary<ushort, GameMounts>();

            string text = Config.GameDataPath + "\\System\\坐骑数据\\";
            if (Directory.Exists(text))
            {
                foreach (var obj in Serializer.Deserialize<GameMounts>(text))
                {
                    obj.Stats = new Dictionary<GameObjectStats, int> {
                        { GameObjectStats.行走速度, obj.速度修改率 / 500 },
                        { GameObjectStats.奔跑速度, obj.速度修改率 / 500 }
                    };
                    DataSheet.Add((obj).坐骑编号, obj);
                }
            }
        }
    }
}
