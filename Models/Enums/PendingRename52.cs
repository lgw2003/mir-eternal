using System;

namespace GameServer.Templates
{
	
	public enum SkillEvasionType  //技能闪避类型
	{
		
		技能无法闪避,  //技能无法闪避
		
		可被物理闪避,  //可被物理闪避
		
		可被魔法闪避,  // 可被魔法闪避
		
		可被中毒闪避,  //可被中毒闪避
		
		非怪物可闪避  //非怪物可闪避
	}
}
