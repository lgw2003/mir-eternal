﻿using System;
using System.Drawing;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 34, Length = 16, Description = "释放技能")]
	public sealed class 玩家释放技能封包 : GamePacket
	{
		
		public 玩家释放技能封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 2)]
		public ushort 技能编号;

		
		[WrappingFieldAttribute(SubScript = 4, Length = 1)]
		public byte 动作编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int 目标编号;

		
		[WrappingFieldAttribute(SubScript = 10, Length = 4)]
		public Point 锚点坐标;

		
		[WrappingFieldAttribute(SubScript = 14, Length = 2)]
		public ushort 锚点高度;
	}
}
