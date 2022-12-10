using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Templates
{
    public sealed class 游戏怪物
    {
        public static Dictionary<string, 游戏怪物> DataSheet;

        public string 怪物名字;
        public ushort 怪物编号;
        public byte 怪物等级;
        public ObjectSize 怪物体型;
        public MonsterRaceType 怪物分类;
        public MonsterLevelType 怪物级别;
        public bool 怪物禁止移动;
        public bool 脱战自动石;
        public ushort 石化状态编号;
        public bool 可见隐身目标;
        public bool 可被技能推动;
        public bool 可被技能控制;
        public bool 可被技能诱惑;
        public float 基础诱惑概率;
        public ushort 怪物移动间隔;
        public ushort 怪物漫游间隔;
        public ushort 尸体保留时长;
        public bool 主动攻击目标;
        public byte 怪物仇恨范围;
        public ushort 怪物仇恨时间;
        public string 普通攻击技能;
        public string 概率触发技能;
        public string 进入战斗技能;
        public string 退出战斗技能;
        public string 移动释放技能;
        public string 出生释放技能;
        public string 死亡释放技能;
        public BasicStats[] 怪物基础;
        public GrowthStat[] 怪物成长;
        public InheritStat[] 继承属性;
        public ushort 怪物提供经验;
        public List<MonsterDrop> 怪物掉落物品;
        public Dictionary<GameItems, long> 掉落统计 = new Dictionary<GameItems, long>();

        private Dictionary<GameObjectStats, int> _怪物基础属性;
        private Dictionary<GameObjectStats, int>[] _怪物成长属性;

        public static void LoadData()
        {
            DataSheet = new Dictionary<string, 游戏怪物>();
            string text = Config.GameDataPath + "\\System\\Npc数据\\怪物数据\\";
            if (Directory.Exists(text))
            {
                var array = Serializer.Deserialize<游戏怪物>(text);
                for (int i = 0; i < array.Length; i++)
                    DataSheet.Add(array[i].怪物名字, array[i]);
            }
        }

        public Dictionary<GameObjectStats, int> BasicStats
        {
            get
            {
                if (_怪物基础属性 != null)
                {
                    return _怪物基础属性;
                }
                _怪物基础属性 = new Dictionary<GameObjectStats, int>();
                if (怪物基础 != null)
                {
                    foreach (BasicStats start in 怪物基础)
                    {
                        _怪物基础属性[start.属性] = start.数值;
                    }
                }
                return _怪物基础属性;
            }
        }

        public Dictionary<GameObjectStats, int>[] GrowStats
        {
            get
            {
                if (_怪物成长属性 != null)
                {
                    return _怪物成长属性;
                }
                _怪物成长属性 = new Dictionary<GameObjectStats, int>[]
                {
                    new Dictionary<GameObjectStats, int>(),
                    new Dictionary<GameObjectStats, int>(),
                    new Dictionary<GameObjectStats, int>(),
                    new Dictionary<GameObjectStats, int>(),
                    new Dictionary<GameObjectStats, int>(),
                    new Dictionary<GameObjectStats, int>(),
                    new Dictionary<GameObjectStats, int>(),
                    new Dictionary<GameObjectStats, int>()
                };
                if (怪物成长 != null)
                {
                    foreach (GrowthStat stat in 怪物成长)
                    {
                        _怪物成长属性[0][stat.属性] = stat.零级;
                        _怪物成长属性[1][stat.属性] = stat.一级;
                        _怪物成长属性[2][stat.属性] = stat.二级;
                        _怪物成长属性[3][stat.属性] = stat.三级;
                        _怪物成长属性[4][stat.属性] = stat.四级;
                        _怪物成长属性[5][stat.属性] = stat.五级;
                        _怪物成长属性[6][stat.属性] = stat.六级;
                        _怪物成长属性[7][stat.属性] = stat.七级;
                    }
                }
                return _怪物成长属性;
            }
        }
    }
}
