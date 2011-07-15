using System;

namespace KalSharp.Packets
{
	public class Unspawn : PacketOut
	{
		public Unspawn(UInt32 worldId) : base(0x38, 4)
		{
			writer.Write(worldId);
		}
	}
}
