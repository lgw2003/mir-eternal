using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 64, Length = 133, Description = "同步玩家外观")]
	public sealed class 同步玩家外观 : GamePacket
	{
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		[WrappingField(SubScript = 6, Length = 1)]
		public byte Unknown1;
		
		[WrappingFieldAttribute(SubScript = 7, Length = 1)]
		public byte 对象职业;
		
		[WrappingFieldAttribute(SubScript = 8, Length = 1)]
		public byte 对象性别;
		
		[WrappingFieldAttribute(SubScript = 9, Length = 1)]
		public byte 对象发型;
		
		[WrappingFieldAttribute(SubScript = 10, Length = 1)]
		public byte 对象发色;
		
		[WrappingFieldAttribute(SubScript = 11, Length = 1)]
		public byte 对象脸型;

		[WrappingFieldAttribute(SubScript = 12, Length = 1)]
		public byte Unknown2;

		[WrappingFieldAttribute(SubScript = 13, Length = 1)]
		public byte Unknown3;

		[WrappingFieldAttribute(SubScript = 14, Length = 1)]
		public int 对象PK值;

		[WrappingFieldAttribute(SubScript = 15, Length = 4)]
		public byte[] Unknown4 = new byte[4];

		[WrappingFieldAttribute(SubScript = 19, Length = 1)]
		public byte 武器等级;
		
		[WrappingFieldAttribute(SubScript = 20, Length = 4)]
		public int 身上武器;
		
		[WrappingFieldAttribute(SubScript = 24, Length = 4)]
		public int 身上衣服;
		
		[WrappingFieldAttribute(SubScript = 28, Length = 4)]
		public int 身上披风;
		
		[WrappingFieldAttribute(SubScript = 32, Length = 4)]
		public int 当前体力;
		
		[WrappingFieldAttribute(SubScript = 36, Length = 4)]
		public int 当前魔力;

		[WrappingFieldAttribute(SubScript = 40, Length = 6)]
		public byte[] Unknown5 = new byte[6];
		
		[WrappingFieldAttribute(SubScript = 46, Length = 4)]
		public int 外观时间;
		
		[WrappingFieldAttribute(SubScript = 50, Length = 1)]
		public byte 摆摊状态;
		
		[WrappingFieldAttribute(SubScript = 51, Length = 0)]
		public string 摆摊名字;
		
		[WrappingFieldAttribute(SubScript = 84, Length = 45)]
		public string 对象名字;
		
		[WrappingFieldAttribute(SubScript = 118, Length = 4)]
		public int 行会编号;
	}
}
