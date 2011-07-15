using System;
using System.Collections.Generic;
using System.Text;

namespace KalSharp.Packets
{
    public class EntityMove : PacketOut
    {
        public EntityMove(uint WorldId, sbyte DX, sbyte DY, sbyte DZ) : base(0x22, 7)
        {
            writer.Write(WorldId);
            writer.Write(DX);
            writer.Write(DY);
            writer.Write(DZ);
        }
    }
}
