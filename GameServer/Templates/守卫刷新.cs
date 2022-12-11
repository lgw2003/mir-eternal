using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace GameServer.Templates
{
	/// <summary>
	/// 守卫刷新
	/// </summary>
	public sealed class 守卫刷新
	{
		public static HashSet<守卫刷新> DataSheet;

		public ushort 守卫编号;
		public byte 所处地图;
		public string 所处地名;
		public Point 所处坐标;
		public GameDirection 所处方向;
		public string 区域名字;

		public static void LoadData()
		{
			DataSheet = new HashSet<守卫刷新>();
			string text = Config.GameDataPath + "\\System\\游戏地图\\守卫刷新\\";
			if (Directory.Exists(text))
			{
				foreach (var obj in Serializer.Deserialize<守卫刷新>(text))
					DataSheet.Add(obj);
			}
		}
	}
}
