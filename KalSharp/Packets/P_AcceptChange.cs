using System;

namespace KalSharp.Packets
{
    public class AcceptChange : PacketOut
    {
        public AcceptChange() : base(0x1d, 1)
        {
            writer.Write((byte)1);
        }
    }
}
