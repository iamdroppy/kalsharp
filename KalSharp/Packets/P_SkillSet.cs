using System;
using System.Collections.Generic;
using System.Text;

namespace KalSharp.Packets
{
    class SkillSet : PacketOut
    {
        public SkillSet(byte skill,byte level) : base(0x51,2)
        {
            writer.Write(skill);
            writer.Write(level);   
        } 
    }
}
