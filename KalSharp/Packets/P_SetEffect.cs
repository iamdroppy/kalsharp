using System;
using System.Drawing;
using KalSharp.Worlds;
using KalSharp.Configs.InitItems.Specialties;

namespace KalSharp.Packets
{
    public enum EffectValue
    {
        LevelUp = 0x03,
    }
    public class SetEffect : PacketOut
    {
        public SetEffect(WorldEntity Entity, EffectValue GState)
            : base(0x49)
        {
            SetCapacity(5);
            writer.Write(Entity.WorldId);
            writer.Write((byte)GState);
        }
    }
}
