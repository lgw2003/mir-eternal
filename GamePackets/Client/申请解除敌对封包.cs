﻿using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 582, Length = 6, Description = "申请解除Hostility")]
	public sealed class 申请解除敌对封包 : GamePacket
	{
		
		public 申请解除敌对封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 行会编号;
	}
}
