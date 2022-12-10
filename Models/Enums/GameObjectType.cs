using System;

namespace GameServer
{
	
	public enum GameObjectType  //游戏对象类型
	{
		玩家 = 1,   //玩家
		宠物 = 2,   //宠物
		怪物 = 4,  //怪物
		Npcc = 8,  
		物品 = 16,  //物品
		陷阱 = 32,  //陷阱
		宝盒 = 64,  //宝盒
	}
}
