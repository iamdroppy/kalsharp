using System;
using System.Collections.Generic;
using System.Text;

namespace KalSharp.Packets 
{
    class OpenDialog : PacketOut
    {
        public OpenDialog(int index) : base(0x4a,4)
        {
            writer.Write(index);
        }
    }
}
