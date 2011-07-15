using System;
using KalSharp.Worlds.Characters;


namespace KalSharp.Packets
{
	public class SetCamera : PacketOut
	{
        public SetCamera(Character Character, ushort mapId)
            : base(0x1b, 10)
		{
			writer.Write(mapId);
            writer.Write(Character.Position.X);
            writer.Write(Character.Position.Y);
		}
	}
}
