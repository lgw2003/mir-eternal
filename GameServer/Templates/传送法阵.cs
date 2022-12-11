using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace GameServer.Templates
{
	/// <summary>
	/// 传送法阵
	/// </summary>
	public class 传送法阵
	{
		public static List<传送法阵> DataSheet;

		public byte 法阵编号;
		public byte 所处地图;
		public byte 跳转地图;
		public string 法阵名字;
		public string 所处地名;
		public string 跳转地名;
		public string 所处别名;
		public string 跳转别名;
		public Point 所处坐标;
		public Point 跳转坐标;

		public static void LoadData()
		{
			DataSheet = new List<传送法阵>();
			string text = Config.GameDataPath + "\\System\\游戏地图\\法阵数据\\";
			if (Directory.Exists(text))
			{
				foreach (var obj in Serializer.Deserialize<传送法阵>(text))
					DataSheet.Add(obj);
			}
		}
	}
}
