using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Templates
{
	/// <summary>
	/// 技能陷阱
	/// </summary>
	public sealed class 技能陷阱
	{
		public static Dictionary<string, 技能陷阱> DataSheet;

		public string 陷阱名字;
		public ushort 陷阱编号;
		public ushort 分组编号;
		public ObjectSize 陷阱体型;
		public ushort 绑定等级;
		public bool 陷阱允许叠加;
		public int 陷阱持续时间;
		public bool 持续时间延长;
		public bool 技能等级延时;
		public int 每级延长时间;
		public bool 角色属性延时;
		public GameObjectStats 绑定角色属性;
		public float 属性延时系数;
		public bool 特定铭文延时;
		public 铭文技能 绑定铭文技能;
		public int 特定铭文技能;
		public int 铭文延长时间;
		public bool 陷阱能否移动;
		public ushort 陷阱移动速度;
		public byte 限制移动次数;
		public bool 当前方向移动;
		public bool 主动追击敌人;
		public byte 陷阱追击范围;
		public string 被动触发技能;
		public bool 禁止重复触发;
		public SpecifyTargetType 被动指定类型;
		public GameObjectType 被动限定类型;
		public GameObjectRelationship 被动限定关系;
		public string 主动触发技能;
		public ushort 主动触发间隔;
		public ushort 主动触发延迟;

		public static void LoadData()
		{
			DataSheet = new Dictionary<string, 技能陷阱>();
			string text = Config.GameDataPath + "\\System\\技能数据\\陷阱数据\\";
			if (Directory.Exists(text))
			{
				foreach (var obj in Serializer.Deserialize<技能陷阱>(text))
					DataSheet.Add(obj.陷阱名字, obj);
			}
		}
	}
}
