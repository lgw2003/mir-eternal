﻿using System;

namespace GameServer.Networking
{
	
	[PacketInfo(Source = PacketSource.Server, Id = 76, Length = 6, Description = "双倍经验变动")]
	public sealed class 双倍经验变动 : GamePacket
	{
		[WrappingField(SubScript = 2, Length = 4)]
		public int DoubleExp;
	}
}
