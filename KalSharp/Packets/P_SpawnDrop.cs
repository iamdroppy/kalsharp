using System;
using System.Collections.Generic;
using System.Text;
using KalSharp.Worlds.Drops;

namespace KalSharp.Packets 
{
    class SpawnDrop : PacketOut
    {
        public SpawnDrop(Drop Drop)
            : base(0x36, 18)
        {
            writer.Write((ushort)Drop.Item.Index);
            writer.Write(Drop.WorldId);
            writer.Write(Drop.Position.X);
            writer.Write(Drop.Position.Y);
            writer.Write(Drop.Item.Num);
            ServerConsole.WriteLine("Spawned DROP");
        }
    }
}
