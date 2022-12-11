using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Templates
{
	/// <summary>
	/// 铭文技能
	/// </summary>
	public sealed class 铭文技能
	{
		public static Dictionary<ushort, 铭文技能> DataSheet;
		private static Dictionary<byte, List<铭文技能>> _概率表;

		public string 技能名字;
		public GameObjectRace 技能职业;
		public ushort 技能编号;
		public byte 铭文编号;
		public byte 技能计数;
		public ushort 计数周期;
		public bool 被动技能;
		public byte 铭文品质;
		public int 洗练概率;
		public bool 广播通知;
		public bool RemoveOnDie;
		public string 铭文描述;
		public byte[] 需要角色等级;
		public int[] 需要技能经验;
		public int[] 技能战力加成;
		public InscriptionStat[] 铭文属性加成;
		public List<ushort> 铭文附带Buff;
		public List<ushort> 被动技能列表;
		public List<string> 主体技能列表;
		public List<string> 开关技能列表;

		private Dictionary<GameObjectStats, int>[] _属性加成;

		public ushort Index
		{
			get
			{
				return (ushort)(技能编号 * 10 + (ushort)铭文编号);
			}
		}

		public Dictionary<GameObjectStats, int>[] StatsBonusDictionary
		{
			get
			{
				if (_属性加成 != null)
				{
					return _属性加成;
				}
				_属性加成 = new Dictionary<GameObjectStats, int>[]
				{
					new Dictionary<GameObjectStats, int>(),
					new Dictionary<GameObjectStats, int>(),
					new Dictionary<GameObjectStats, int>(),
					new Dictionary<GameObjectStats, int>()
				};
				if (铭文属性加成 != null)
				{
					foreach (InscriptionStat 铭文Stat in 铭文属性加成)
					{
						_属性加成[0][铭文Stat.属性] = 铭文Stat.零级;
						_属性加成[1][铭文Stat.属性] = 铭文Stat.一级;
						_属性加成[2][铭文Stat.属性] = 铭文Stat.二级;
						_属性加成[3][铭文Stat.属性] = 铭文Stat.三级;
					}
				}
				return _属性加成;
			}
		}

		public static 铭文技能 RandomWashing(byte cleanUpRace)
		{
			List<铭文技能> list;
			if (_概率表.TryGetValue(cleanUpRace, out list) && list.Count > 0)
				return list[MainProcess.RandomNumber.Next(list.Count)];
			return null;
		}
		
		public static void LoadData()
		{
			DataSheet = new Dictionary<ushort, 铭文技能>();
			string text = Config.GameDataPath + "\\System\\技能数据\\铭文数据\\";
			
			if (Directory.Exists(text))
			{
				foreach (var obj in Serializer.Deserialize<铭文技能>(text))
					DataSheet.Add(obj.Index, obj);
			}

            var dictionary = new Dictionary<byte, List<铭文技能>>
            {
                [0] = new List<铭文技能>(),
                [1] = new List<铭文技能>(),
                [2] = new List<铭文技能>(),
                [3] = new List<铭文技能>(),
                [4] = new List<铭文技能>(),
                [5] = new List<铭文技能>()
            };

            _概率表 = dictionary;
			foreach (铭文技能 skill in DataSheet.Values)
			{
				if (skill.铭文编号 != 0)
				{
					for (int j = 0; j < skill.洗练概率; j++)
					{
						_概率表[(byte)skill.技能职业].Add(skill);
					}
				}
			}
			foreach (var list in _概率表.Values)
			{
				for (int k = 0; k < list.Count; k++)
				{
					铭文技能 value = list[k];
					int index = MainProcess.RandomNumber.Next(list.Count);
					list[k] = list[index];
					list[index] = value;
				}
			}
		}
	}
}
