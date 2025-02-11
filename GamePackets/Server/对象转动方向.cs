﻿using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 50, Length = 10, Description = "对象转动", Broadcast = true)]
	public sealed class 对象转动方向 : GamePacket
	{
		
		public 对象转动方向()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 2)]
		public ushort 转向耗时;

		
		[WrappingFieldAttribute(SubScript = 8, Length = 2)]
		public ushort 对象朝向;
	}
}
