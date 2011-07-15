using System;
using KalSharp.Worlds.Characters;

namespace KalSharp.Packets
{
    public class ValueChange : PacketOut
    {
        public ValueChange(byte index, byte v) : base(0x45,2)
        {
            writer.Write(index);
            writer.Write(v);
        }
        
        public ValueChange(byte index, ushort v) : base(0x45,3)
        {
            writer.Write(index);
            writer.Write(v);
        }
        
        public ValueChange(byte index, ushort v1, ushort v2) : base(0x45,5)
        {
            writer.Write(index);
            writer.Write(v1);
            writer.Write(v2);
        }
        
        public ValueChange(byte index, long v1, long v2) : base(0x45,17)
        {
            writer.Write((byte)0x19);
            writer.Write(v1);
            writer.Write(v2);
        }

        public ValueChange(Character Character, byte index, ushort value)
            : base(0x48, 7)
        {
            writer.Write(Character.WorldId);
            writer.Write(index);
            writer.Write(value);
        }

        public ValueChange(Character Character, byte index, uint value)
            : base(0x48, 7)
        {
            writer.Write(Character.WorldId);
            writer.Write(index);
            writer.Write(value);
        }
    }
}