using System;

namespace GameServer.Templates
{
	[Flags]
	public enum GameObjectRelationship
	{
		自身 = 1,
		友方 = 2,
		敌对 = 4
	}
}
