using System;
using System.Collections.Generic;
using System.Text;
using KalSharp.Worlds.Npcs;

namespace KalSharp.Packets
{
    class SpawnNpc : PacketOut
    {
        public SpawnNpc(Npc Npc) : base(0x34,29)
        {
            writer.Write(Npc.WorldId);
            writer.Write((ushort)Npc.Index);
            writer.Write((byte)Npc.Shape);
            writer.Write(Npc.Position.X);
            writer.Write(Npc.Position.Y);
            writer.Write(Npc.Position.Z);
            writer.Write(Npc.Direction.X);
            writer.Write(Npc.Direction.Y);
            
            for(int i=0;i<8;i++) {
                writer.Write((byte)0);
            }
        }        
    }
}
