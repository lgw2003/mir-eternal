using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 143, Length = 8, Description = "装备持久改变")]
	public sealed class 装备持久改变 : GamePacket
	{
		
		public 装备持久改变()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 装备容器;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 1)]
		public byte 装备位置;

		
		[WrappingFieldAttribute(SubScript = 4, Length = 4)]
		public int 当前持久;
	}
}
