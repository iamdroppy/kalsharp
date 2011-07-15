using System;
using System.Collections.Generic;
using System.Text;
using KalSharp.Worlds.Items;

namespace KalSharp.Packets 
{
    class PickupDrop : PacketOut
    {
        public PickupDrop(UInt32 WorlId)
            : base(0x3b, 4)
        {
            writer.Write(WorlId);
            ServerConsole.WriteLine("Pickeup drop {0}", MessageLevel.Message, WorlId);
        }
    }
    
}
