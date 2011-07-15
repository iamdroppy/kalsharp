using System;
using System.Collections;

using KalSharp.Worlds.Skills;

namespace KalSharp.Packets
{
    public class SendSkills : PacketOut
    {
        public SendSkills(Player player)
            : base(0x10)
        {
            SetCapacity((ushort)((player.Skills.Count * 2) + 1));

            writer.Write((byte)player.Skills.Count);

            foreach (PlayerSkill skill in player.Skills)
            {
                writer.Write((byte)skill.SkillIndex);
                writer.Write((byte)skill.Level);
            }
        }
    }
}
