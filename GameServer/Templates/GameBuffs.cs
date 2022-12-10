using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Templates
{
	/// <summary>
	/// 游戏Buff
	/// </summary>
	public sealed class GameBuffs
	{
		public static Dictionary<ushort, GameBuffs> DataSheet;

		public string Buff名字;
		public ushort Buff编号;
		public ushort 分组编号;
		public BuffActionType 作用类型;
		public BuffOverlayType 叠加类型;
		public BuffEffectType Buff效果;
		public bool 同步至客户端;
		public bool 到期主动消失;
		public bool 切换地图消失;
		public bool 切换武器消失;
		public bool 角色死亡消失;
		public bool 角色下线消失;
		public bool OnReleaseSkillRemove;
		public ushort 绑定技能等级;
		public bool 移除添加冷却;
		public ushort 技能冷却时间;
		public byte Buff初始层数;
		public byte Buff最大层数;
		public bool Buff允许合成;
		public byte Buff合成层数;
		public ushort Buff合成编号;
		public int Buff处理间隔;
		public int Buff处理延迟;
		public int Buff持续时间;
		public bool 持续时间延长;
		public ushort 后接Buff编号;
		public ushort 连带Buff编号;
		public ushort[] 依存Buff列表;
		public bool 技能等级延时;
		public int 每级延长时间;
		public bool 角色属性延时;
		public GameObjectStats 绑定角色属性;
		public float 属性延时系数;
		public bool 特定铭文延时;
		public int 特定铭文技能;
		public int 铭文延长时间;
		public GameObjectState 角色所处状态;
		public InscriptionStat[] 属性增减;
		public SkillDamageType Buff伤害类型;
		public int[] Buff伤害基数;
		public float[] Buff伤害系数;
		public int 强化铭文编号;
		public int 铭文强化基数;
		public float 铭文强化系数;
		public bool 效果生效移除;
		public ushort 生效后接编号;
		public bool 后接技能来源;
		public BuffDetherminationMethod 效果判定方式;
		public bool 限定伤害上限;
		public int 限定伤害数值;
		public BuffJudgmentType 效果判定类型;
		public HashSet<ushort> 特定技能编号;
		public int[] 伤害增减基数;
		public float[] 伤害增减系数;
		public string 触发陷阱技能;
		public ObjectSize 触发陷阱数量;
		public byte[] 体力回复基数;
		public int 诱惑时长增加;
		public float 诱惑概率增加;
		public byte 诱惑等级增加;

		private Dictionary<GameObjectStats, int>[] _基础属性增减;

		public static void LoadData()
		{
			DataSheet = new Dictionary<ushort, GameBuffs>();
			string text = Config.GameDataPath + "\\System\\技能数据\\Buff数据\\";
			if (Directory.Exists(text))
			{
				foreach (var obj in Serializer.Deserialize<GameBuffs>(text))
					DataSheet.Add(obj.Buff编号, obj);
			}
		}
		
		public Dictionary<GameObjectStats, int>[] 基础StatsIncOrDec
		{
			get
			{
				if (_基础属性增减 != null)
				{
					return _基础属性增减;
				}
				_基础属性增减 = new Dictionary<GameObjectStats, int>[]
				{
					new Dictionary<GameObjectStats, int>(),
					new Dictionary<GameObjectStats, int>(),
					new Dictionary<GameObjectStats, int>(),
					new Dictionary<GameObjectStats, int>()
				};
				if (属性增减 != null)
				{
					foreach (InscriptionStat stat in 属性增减)
					{
						_基础属性增减[0][stat.属性] = stat.零级;
						_基础属性增减[1][stat.属性] = stat.一级;
						_基础属性增减[2][stat.属性] = stat.二级;
						_基础属性增减[3][stat.属性] = stat.三级;
					}
				}
				return _基础属性增减;
			}
		}

		
	}
}
