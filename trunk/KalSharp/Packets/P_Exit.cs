using System;

namespace KalSharp.Packets
{
	public class Exit : PacketOut
	{
		public Exit() : base(0x5d,1)
		{
			writer.Write((byte)1);
		}
	}
}
