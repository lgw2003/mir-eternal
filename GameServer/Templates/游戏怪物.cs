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
        public bool CanBeSeducedBySkills;
        public float BaseTemptationProbability;
        public ushort 怪物移动间隔;
        public ushort 怪物漫游间隔;
        public ushort 尸体保留时长;
        public bool 主动攻击目标;
        public byte 怪物仇恨范围;
        public ushort 怪物仇恨时间;
        public string 普通攻击技能;
        public string ProbabilityTriggerSkills;
        public string EnterCombatSkills;
        public string ExitCombatSkills;
        public string MoveReleaseSkill;
        public string BirthReleaseSkill;
        public string DeathReleaseSkill;
        public BasicStats[] 怪物基础;
        public GrowthStat[] Grows;
        public InheritStat[] InheritsStats;
        public ushort ProvideExperience;
        public List<MonsterDrop> Drops;
        public Dictionary<GameItems, long> DropStats = new Dictionary<GameItems, long>();

        private Dictionary<GameObjectStats, int> _basicStats;
        private Dictionary<GameObjectStats, int>[] _growStats;

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
                if (_basicStats != null)
                {
                    return _basicStats;
                }
                _basicStats = new Dictionary<GameObjectStats, int>();
                if (怪物基础 != null)
                {
                    foreach (BasicStats start in 怪物基础)
                    {
                        _basicStats[start.属性] = start.数值;
                    }
                }
                return _basicStats;
            }
        }

        public Dictionary<GameObjectStats, int>[] GrowStats
        {
            get
            {
                if (_growStats != null)
                {
                    return _growStats;
                }
                _growStats = new Dictionary<GameObjectStats, int>[]
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
                if (Grows != null)
                {
                    foreach (GrowthStat stat in Grows)
                    {
                        _growStats[0][stat.Stat] = stat.Level0;
                        _growStats[1][stat.Stat] = stat.Level1;
                        _growStats[2][stat.Stat] = stat.Level2;
                        _growStats[3][stat.Stat] = stat.Level3;
                        _growStats[4][stat.Stat] = stat.Level4;
                        _growStats[5][stat.Stat] = stat.Level5;
                        _growStats[6][stat.Stat] = stat.Level6;
                        _growStats[7][stat.Stat] = stat.Level7;
                    }
                }
                return _growStats;
            }
        }
    }
}
