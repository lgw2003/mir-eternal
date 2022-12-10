using System;

namespace GameServer.Templates
{
	
	public sealed class B_00_技能切换通知 : SkillTask
	{
		
		public B_00_技能切换通知()
		{
			
			
		}

		
		public ushort 技能标记编号;

		
		public bool 允许移除标记;

		public int 角色忙绿时间;
	}
}
