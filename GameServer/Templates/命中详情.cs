using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GameServer.Maps;

namespace GameServer.Templates
{
	
	public class 命中详情
	{
		public int Damage;
		public ushort MissDamage;
		public MapObject Object;
		public SkillHitFeedback Feedback;

		public 命中详情(MapObject obj, SkillHitFeedback feedback = default)
		{
			Object = obj;
			Feedback = feedback;
		}
		
		public static byte[] GetHitDescription(Dictionary<int, 命中详情> hitList, int hitDelay)
		{
            using var memoryStream = new MemoryStream();
            using var binaryWriter = new BinaryWriter(memoryStream);
            
			binaryWriter.Write((byte)hitList.Count);
            foreach (var item in hitList.ToList())
            {
                binaryWriter.Write(item.Value.Object.ObjectId);
                binaryWriter.Write((ushort)item.Value.Feedback);
                binaryWriter.Write((ushort)hitDelay);
            }
            return memoryStream.ToArray();
        }
	}
}
