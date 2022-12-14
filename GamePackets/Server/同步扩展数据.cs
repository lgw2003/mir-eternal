using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 66, Length = 58, Description = "同步Npcc数据扩展(宠物)")]
	public sealed class 同步扩展数据 : GamePacket
	{
		
		public 同步扩展数据()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 2)]
		public ushort 模板编号;

		
		[WrappingFieldAttribute(SubScript = 10, Length = 1)]
		public byte 对象质量;

		
		[WrappingFieldAttribute(SubScript = 11, Length = 1)]
		public byte 对象等级;

		
		[WrappingFieldAttribute(SubScript = 12, Length = 4)]
		public int 最大体力;

		
		[WrappingFieldAttribute(SubScript = 16, Length = 1)]
		public byte 对象类型;

		
		[WrappingFieldAttribute(SubScript = 17, Length = 1)]
		public byte 当前等级;

		
		[WrappingFieldAttribute(SubScript = 18, Length = 4)]
		public int 主人编号;

		
		[WrappingFieldAttribute(SubScript = 22, Length = 36)]
		public string 主人名字;
	}
}
