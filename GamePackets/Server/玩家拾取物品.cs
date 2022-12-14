using System;

namespace GameServer.Networking
{
	
	[PacketInfo(Source = PacketSource.Server, Id = 135, Length = 0, Description = "拾取物品")]
	public sealed class 玩家拾取物品 : GamePacket
	{
		[WrappingFieldAttribute(SubScript = 4, Length = 4)]
		public int 角色编号;

		[WrappingField(SubScript = 8, Length = 0)]
		public byte[] 物品描述 = Array.Empty<byte>();
	}
}
