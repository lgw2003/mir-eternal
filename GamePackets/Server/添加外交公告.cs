﻿using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 608, Length = 38, Description = "添加外交公告")]
	public sealed class 添加外交公告 : GamePacket
	{
		
		public 添加外交公告()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 外交类型;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 4)]
		public int 行会编号;

		
		[WrappingFieldAttribute(SubScript = 7, Length = 4)]
		public int 外交时间;

		
		[WrappingFieldAttribute(SubScript = 11, Length = 1)]
		public byte 行会等级;

		
		[WrappingFieldAttribute(SubScript = 12, Length = 1)]
		public byte 行会人数;

		
		[WrappingFieldAttribute(SubScript = 13, Length = 25)]
		public string GuildName;
	}
}
