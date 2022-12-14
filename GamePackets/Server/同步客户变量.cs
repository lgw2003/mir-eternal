using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 186, Length = 514, Description = "同步客户变量(物品快捷键)")]
	public sealed class 同步客户变量 : GamePacket
	{
		
		public 同步客户变量()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 512)]
		public byte[] 字节数据;
	}
}
