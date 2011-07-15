using System;
using System.Collections.Generic;
using System.Text;

namespace KalSharp.Packets
{
    class Ping : PacketOut
    {
        public Ping()
            : base(0x1E, 0)
        {  
        } 
    }
}
