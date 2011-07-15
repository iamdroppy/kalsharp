using System;

namespace KalSharp.Packets
{
	public class LoginAccepted : PacketOut
	{
		public LoginAccepted() : base(0x04, 1)
		{
			writer.Write((byte)0);
		}
	}
}
