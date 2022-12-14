using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 540, Length = 6, Description = "拒绝收徒申请")]
	public sealed class 拒绝收徒申请封包 : GamePacket
	{
		
		public 拒绝收徒申请封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
