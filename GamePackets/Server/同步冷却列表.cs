﻿using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 108, Length = 0, Description = "同步冷却列表")]
	public sealed class 同步冷却列表 : GamePacket
	{
		
		public 同步冷却列表()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 字节描述;
	}
}
