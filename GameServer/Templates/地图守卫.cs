using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Templates
{
	/// <summary>
	/// 守卫
	/// </summary>
	public sealed class 地图守卫
	{
		public static Dictionary<ushort, 地图守卫> DataSheet;

		public string 守卫名字;
		public ushort 守卫编号;
		public byte 守卫等级;
		public bool 虚无状态;
		public bool 能否受伤;
		public int 尸体保留;
		public int 复活间隔;
		public bool 主动攻击;
		public byte 仇恨范围;
		public string 普攻技能;
		public int 商店编号;
		public string 界面代码;

		public static void LoadData()
		{
			DataSheet = new Dictionary<ushort, 地图守卫>();
			string text = Config.GameDataPath + "\\System\\Npc数据\\守卫数据\\";

			if (Directory.Exists(text))
			{
				foreach (var obj in Serializer.Deserialize<地图守卫>(text))
					DataSheet.Add(obj.守卫编号, obj);
			}
		}
	}
}
