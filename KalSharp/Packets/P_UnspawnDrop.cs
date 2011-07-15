using System;
using KalSharp.Worlds.Drops;

namespace KalSharp.Packets
{
	public class UnspawnDrop : PacketOut
	{
		public UnspawnDrop(Drop drop) : base(0x3b, 4)
		{
			writer.Write(drop.WorldId);
		}
	}
}