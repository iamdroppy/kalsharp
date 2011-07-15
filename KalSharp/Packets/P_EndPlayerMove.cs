using System;
using System.Collections.Generic;
using System.Text;

namespace KalSharp.Packets
{
    public class EndPlayerMove : PacketOut
    {
        public EndPlayerMove(uint WorldId, sbyte DX, sbyte DY, sbyte DZ) : base(0x23, 7)
        {
            writer.Write(WorldId);
            writer.Write(DX);
            writer.Write(DY);
            writer.Write(DZ);
        }
    }
}
