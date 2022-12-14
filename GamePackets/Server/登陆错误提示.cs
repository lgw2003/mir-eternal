using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 1001, Length = 14, Description = "登录服务器,错误提示")]
	public sealed class 登陆错误提示 : GamePacket
	{
		
		public 登陆错误提示()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public uint 错误代码;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int 参数一;

		
		[WrappingFieldAttribute(SubScript = 10, Length = 4)]
		public int 参数二;
	}
}
