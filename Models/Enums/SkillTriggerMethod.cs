using System;

namespace GameServer.Templates
{
	/// <summary>
	/// 技能触发方式
	/// </summary>
	public enum SkillTriggerMethod
	{
		原点位置绝对触发,
		锚点位置绝对触发,
		刺杀位置绝对触发,
		目标命中绝对触发,
		怪物死亡绝对触发,
		怪物死亡换位触发,
		怪物命中绝对触发,
		怪物命中概率触发, //怪物命中概率
		无目标锚点位触发,
		目标位置绝对触发,
		正手反手随机触发,
		目标死亡绝对触发,
		目标闪避绝对触发
	}
}
