using System;
using KalSharp.Worlds.Drops;

namespace KalSharp.Packets
{
	public class Disconnect : PacketOut
	{
        public Disconnect()
            : base(0x1a, 1)
		{
            writer.Write(0x00);
		}
	}
}