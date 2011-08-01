using System;
using System.Drawing;
using KalSharp.Worlds;
using KalSharp.Configs.Items.Specialties;

namespace KalSharp.Packets
{
    public class SetGState : PacketOut
    {
        public SetGState(WorldEntity Entity, GStateValue GState) : base(0x3d)
        {
            SetCapacity(5);
            writer.Write(Entity.WorldId);
            writer.Write((byte)GState);
        }
    }
}
