using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GameServer.Templates
{
	/// <summary>
	/// NPC对话
	/// </summary>
	public sealed class NpcDialogs
	{

		public static Dictionary<int, string> DataSheet;
		public static Dictionary<int, byte[]> DataById;

		public int 对话编号;
		public string 对话内容;

        /// <summary>
        /// 获取对话字节数据
        /// </summary>
        /// <param name="npcDialogId">对话编号</param>
        /// <returns></returns>
        public static byte[] GetBufferFromDialogId(int npcDialogId)
		{
			byte[] result;
			if (DataById.TryGetValue(npcDialogId, out result))
			{
				return result;
			}
			string str;
			if (DataSheet.TryGetValue(npcDialogId, out str))
			{
				return DataById[npcDialogId] = Encoding.UTF8.GetBytes(str + "\0");
			}
			return new byte[0];
		}

		/// <summary>
		/// 获取混合对话字节数据
		/// </summary>
		/// <param name="npcDialogId">对话编号</param>
		/// <param name="content">混合内容</param>
		/// <returns></returns>
		public static byte[] CombineDialog(int npcDialogId, string content)
		{
			byte[] second;
			if (DataById.TryGetValue(npcDialogId, out second))
			{
				return Encoding.UTF8.GetBytes(content).Concat(second).ToArray<byte>();
			}
			string str;
			if (DataSheet.TryGetValue(npcDialogId, out str))
			{
				return Encoding.UTF8.GetBytes(content).Concat(DataById[npcDialogId] = Encoding.UTF8.GetBytes(str + "\0")).ToArray<byte>();
			}
			return new byte[0];
		}

		
		public static void LoadData()
		{
			DataSheet = new Dictionary<int, string>();
			DataById = new Dictionary<int, byte[]>();
			string text = Config.GameDataPath + "\\System\\Npc数据\\对话数据\\";

			if (Directory.Exists(text))
			{
				foreach (var obj in Serializer.Deserialize<NpcDialogs>(text))
					DataSheet.Add(obj.对话编号, obj.对话内容);
			}
		}
	}
}
