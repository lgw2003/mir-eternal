﻿using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 519, 长度 = 44, 注释 = "申请更改队伍")]
	public sealed class 申请更改队伍 : GamePacket
	{
		
		public 申请更改队伍()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 成员上限;

		
		[WrappingFieldAttribute(下标 = 8, 长度 = 4)]
		public int 队长编号;
	}
}
