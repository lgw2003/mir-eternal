﻿using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 547, Length = 0, Description = "查询师门成员(师徒通用)")]
	public sealed class 查询师门成员 : GamePacket
	{
		
		public 查询师门成员()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 字节数据;
	}
}
