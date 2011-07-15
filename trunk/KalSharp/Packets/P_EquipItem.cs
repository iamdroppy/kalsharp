using System;
using System.Collections.Generic;
using System.Text;
using KalSharp.Worlds.Items;
using KalSharp.Worlds;

namespace KalSharp.Packets 
{
    public class EquipItem : PacketOut
    {
        public EquipItem(Item Item, WorldEntity Entity)
            : base(0x05, 10)
        {
            writer.Write(Entity.WorldId);
            writer.Write(Item.IID);
            writer.Write((ushort)Item.Index);
        }
    }
}
