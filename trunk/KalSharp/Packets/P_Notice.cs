using System;
using System.Collections.Generic;
using System.Text;

namespace KalSharp.Packets
{
    class Notice : PacketOut
    {
        public Notice(string message) : base(0x0f)
        {
            writer.Write(message.ToCharArray());
            writer.Write((byte)0);
        }   
    }
}
