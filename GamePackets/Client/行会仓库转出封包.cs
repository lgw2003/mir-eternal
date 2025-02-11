﻿using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 166, Length = 8, Description = "行会仓库转出")]
	public sealed class 行会仓库转出封包 : GamePacket
	{
		
		public 行会仓库转出封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 仓库页面;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 1)]
		public byte 仓库位置;

		
		[WrappingFieldAttribute(SubScript = 4, Length = 1)]
		public byte 目标容器;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 1)]
		public byte 目标位置;
	}
}
