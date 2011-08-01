using System;
using System.Collections.Generic;
using System.Text;
using KalSharp.Worlds.Items;
using KalSharp.Worlds;

namespace KalSharp.Packets 
{
    public class UnequipItem : PacketOut
    {
        public UnequipItem(PlayerItem PlayerItem, WorldEntity Entity)
            : base(0x06, 10)
        {
            writer.Write(Entity.WorldId);
            writer.Write(PlayerItem.IID);
            writer.Write((ushort)PlayerItem.Index);
        }
    }
}
