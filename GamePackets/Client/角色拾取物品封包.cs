using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 48, Length = 7, Description = "角色拾取物品")]
	public sealed class 角色拾取物品封包 : GamePacket
	{
		
		public 角色拾取物品封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 物品编号;
	}
}
