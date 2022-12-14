using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 101, Length = 6, Description = "角色装配铭文")]
	public sealed class 角色装配铭文 : GamePacket
	{
		
		public 角色装配铭文()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 2)]
		public ushort 技能编号;

		
		[WrappingFieldAttribute(SubScript = 4, Length = 1)]
		public byte 铭文编号;

		
		[WrappingFieldAttribute(SubScript = 5, Length = 1)]
		public byte 技能等级;
	}
}
