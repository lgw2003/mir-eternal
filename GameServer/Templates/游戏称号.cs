using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Templates
{
	/// <summary>
	/// 游戏称号
	/// </summary>
	public sealed class 游戏称号
	{
		public static Dictionary<byte, 游戏称号> DataSheet;

		public byte 称号编号;
		public string 称号名字;
		public int 称号战力;
		public int 有效时间;
		public Dictionary<GameObjectStats, int> 称号属性;

		public static void LoadData()
		{
			DataSheet = new Dictionary<byte, 游戏称号>();
			string text = Config.GameDataPath + "\\System\\物品数据\\游戏称号\\";
			if (Directory.Exists(text))
			{
				var array = Serializer.Deserialize<游戏称号>(text);
				for (int i = 0; i < array.Length; i++)
					DataSheet.Add(array[i].称号编号, array[i]);
			}
		}
	}
}
