using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 89, Length = 9, Description = "角色学习技能")]
	public sealed class 角色学习技能 : GamePacket
	{
		
		public 角色学习技能()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 角色编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 2)]
		public ushort 技能编号;
	}
}
