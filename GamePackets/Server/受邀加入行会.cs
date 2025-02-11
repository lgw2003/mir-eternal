﻿using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 594, Length = 63, Description = "受邀加入行会")]
	public sealed class 受邀加入行会 : GamePacket
	{
		
		public 受邀加入行会()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 32)]
		public string 对象名字;

		
		[WrappingFieldAttribute(SubScript = 38, Length = 25)]
		public string GuildName;
	}
}
