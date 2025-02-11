﻿using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 521, Length = 52, Description = "队伍状态改变")]
	public sealed class 队伍状态改变 : GamePacket
	{
		
		public 队伍状态改变()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 队伍编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 32)]
		public string 队伍名字;

		
		[WrappingFieldAttribute(SubScript = 38, Length = 4)]
		public int 成员上限;

		
		[WrappingFieldAttribute(SubScript = 42, Length = 1)]
		public byte 分配方式;

		
		[WrappingFieldAttribute(SubScript = 44, Length = 4)]
		public int 队长编号;
	}
}
