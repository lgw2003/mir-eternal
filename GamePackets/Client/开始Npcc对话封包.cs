using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 117, Length = 6, Description = "点击Npc开始与之对话")]
	public sealed class 开始Npcc对话封包 : GamePacket
	{
		
		public 开始Npcc对话封包()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
