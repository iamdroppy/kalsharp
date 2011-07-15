using System;
using KalSharp.Worlds.Characters;

namespace KalSharp.Packets
{
	public class PlayerInfo : PacketOut
	{
        public PlayerInfo(Character Character)
            : base(0x42, 59)
		{
            writer.Write((byte)Character.Player.Specialty);
			writer.Write((ushort)0);
			// Contribution
            writer.Write((ushort)Character.Player.Contribute);	
		    // Stats	
            writer.Write(Character.Stats.Strength);
            writer.Write(Character.Stats.Health);
            writer.Write(Character.Stats.Intelligence);
            writer.Write(Character.Stats.Wisdom);
            writer.Write(Character.Stats.Dexterity);
			// Health
            writer.Write((ushort)Character.CurrentHP);
            writer.Write(Character.Stats.MaximumHP);
            // Mana
            writer.Write((ushort)Character.CurrentMP);
            writer.Write(Character.Stats.MaximumMP);
			// Special stats
            writer.Write(Character.Stats.OTP);
            writer.Write(Character.Stats.Evasion);
            writer.Write(Character.Stats.Defense);
            writer.Write(Character.Stats.Absorb);
			// Other
            writer.Write(Character.Player.Experience);
            // Damage			
            writer.Write(Character.Stats.MinDamage);
            writer.Write(Character.Stats.MaxDamage);
            writer.Write(Character.Stats.MinMagicalDamage);
            writer.Write(Character.Stats.MaxMagicalDamage);
            // Points
            writer.Write((short)Character.Player.StatPoints);
            writer.Write((short)Character.Player.SkillPoints);
			// Resistance
            writer.Write(Character.Stats.FireResistance);
            writer.Write(Character.Stats.IceResistance);
            writer.Write(Character.Stats.LightningResistance);
            writer.Write(Character.Stats.CurseResistance);
            writer.Write(Character.Stats.ParalysisResistance);
			// Rage
            writer.Write((int)Character.Player.Rage);
		}
	}
}
