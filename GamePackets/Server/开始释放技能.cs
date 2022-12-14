using System;
using System.Drawing;

namespace GameServer.Networking
{
	
	[PacketInfo(Source = PacketSource.Server, Id = 94, Length = 25, Description = "开始释放技能(技能信息,目标,坐标,速率)", Broadcast = true)]
	public sealed class StartToReleaseSkillPacket : GamePacket
	{
		[WrappingField(SubScript = 2, Length = 4)]
		public int 对象编号;
		
		[WrappingField(SubScript = 6, Length = 2)]
		public ushort 技能编号;
		
		[WrappingField(SubScript = 8, Length = 1)]
		public byte 技能等级;
		
		[WrappingField(SubScript = 9, Length = 1)]
		public byte 技能铭文;
		
		[WrappingField(SubScript = 10, Length = 4)]
		public int 目标编号;
		
		[WrappingField(SubScript = 14, Length = 4)]
		public Point 锚点坐标;
		
		[WrappingField(SubScript = 18, Length = 2)]
		public ushort 锚点高度;

		[WrappingField(SubScript = 20, Length = 2)]
		public ushort 加速率一 = 10000;
		
		[WrappingField(SubScript = 22, Length = 2)]
		public ushort 加速率二 = 10000;
		
		[WrappingField(SubScript = 24, Length = 1)]
		public byte 动作编号;
	}
}
