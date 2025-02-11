﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace GameServer.Templates
{
	/// <summary>
	/// 怪物刷新
	/// </summary>
	public class 怪物刷新
	{
		public static HashSet<怪物刷新> DataSheet;

		public byte 所处地图;
		public string 所处地名;
		public Point 所处坐标;
		public string 区域名字;
		public int 区域半径;
		public MonsterSpawnInfo[] 刷新列表;
		public HashSet<Point> 范围坐标;

		public static void LoadData()
		{
			DataSheet = new HashSet<怪物刷新>();
			string text = Config.GameDataPath + "\\System\\游戏地图\\怪物刷新\\";
			if (Directory.Exists(text))
			{
				foreach (var obj in Serializer.Deserialize<怪物刷新>(text))
					DataSheet.Add(obj);
			}
		}
	}
}
