using System;
using System.Collections.Generic;
using System.Text;
using KalSharp.Worlds.Characters;
using KalSharp.Worlds.Stats;
using KalSharp.Worlds;

namespace KalSharp.Packets
{
    public class StatPacket
    {
        public class EditPacket : PacketOut
        {
            public EditPacket(byte index, ushort size) : base(0x45,(ushort)(size + 1))
            {
                writer.Write(index);
            }            
        }
        
        public class Strength : EditPacket
        {
            public Strength(Character Character)
                : base(0x00, 7)
            {
                writer.Write(Character.Stats.Strength);
                writer.Write(Character.Stats.OTP);
                writer.Write(Character.Stats.MinDamage);
                writer.Write(Character.Stats.MaxDamage);   
            }
        }
        
        public class Health : EditPacket
        {
            public Health(Character Character)
                : base(0x01, 7)
            {
                writer.Write(Character.Stats.Health);
                writer.Write(Character.CurrentHP);
                writer.Write(Character.Stats.MaximumHP);
                writer.Write(Character.Stats.ParalysisResistance);   
            }
        }
        
        public class Intelligence : EditPacket
        {
            public Intelligence(Character Character)
                : base(0x02, 11)
            {
                writer.Write(Character.Stats.Intelligence);
                writer.Write(Character.Stats.MinMagicalDamage);
                writer.Write(Character.Stats.MaxMagicalDamage);
                writer.Write(Character.Stats.FireResistance);
                writer.Write(Character.Stats.IceResistance);
                writer.Write(Character.Stats.LightningResistance);   
            }
        }
                
        public class Wisdom : EditPacket
        {
            public Wisdom(Character Character)
                : base(0x03, 7)
            {
                writer.Write(Character.Stats.Wisdom);
                writer.Write(Character.CurrentMP);
                writer.Write(Character.Stats.MaximumMP);
                writer.Write(Character.Stats.CurseResistance);   
            }
        }

        public class Agility : EditPacket
        {
            public Agility(Character Character)
                : base(0x04, 9)
            {
                writer.Write(Character.Stats.Dexterity);
                writer.Write(Character.Stats.OTP);
                writer.Write(Character.Stats.Evasion);
                writer.Write(Character.Stats.MinDamage);
                writer.Write(Character.Stats.MaxDamage);
            }
        }
        public class Defense : EditPacket
        {
            public Defense(Character Character)
                : base(0x0f, 2)
            {
                writer.Write(Character.Stats.Defense);
            }
        }
        public class Evasion : EditPacket
        {
            public Evasion(Character Character)
                : base(0x0a, 2)
            {
                writer.Write(Character.Stats.Evasion);
            }
        }
        public class Attack : EditPacket
        {
            public Attack(Character Character)
                : base(0x1b, 4)
            {
                writer.Write(Character.Stats.MinDamage);
                writer.Write(Character.Stats.MaxDamage);
            }
        }
        public class Magic : EditPacket
        {
            public Magic(Character Character)
                : base(0x1c, 4)
            {
                writer.Write(Character.Stats.MinMagicalDamage);
                writer.Write(Character.Stats.MaxMagicalDamage);
            }
        }
        public class Contribution : EditPacket
        {
            public Contribution(Character Character)
                : base(0x1e, 2)
            {
                writer.Write((ushort)Character.Player.Contribute);
            }
        }
        public class OTP : EditPacket
        {
            public OTP(Character Character)
                : base(0x09, 2)
            {
                writer.Write(Character.Stats.OTP);
            }
        }
        public class Absorption : EditPacket
        {
            public Absorption(Character Character)
                : base(0x10, 2)
            {
                writer.Write((short)Character.Stats.Absorb);
            }
        }
        public class AttackSpeed : EditPacket
        {
            public AttackSpeed(Character Character)
                : base(0x11, 2)
            {
                writer.Write(Character.Stats.AttackSpeed);
            }
        }
        //fire
        //ice
        //lightning
        //cure
        //non elemental

        public class FireResistance : EditPacket
        {
            public FireResistance(Character Character)
                : base(0x12, 2)
            {
                writer.Write(Character.Stats.FireResistance);
            }
        }
        public class IceResistance : EditPacket
        {
            public IceResistance(Character Character)
                : base(0x13, 2)
            {
                writer.Write(Character.Stats.IceResistance);
            }
        }
        public class LightningResistance : EditPacket
        {
            public LightningResistance(Character Character)
                : base(0x14, 2)
            {
                writer.Write(Character.Stats.LightningResistance);
            }
        }
        public class CurseResistance : EditPacket
        {
            public CurseResistance(Character Character)
                : base(0x15, 2)
            {
                writer.Write(Character.Stats.CurseResistance);
            }
        }
        public class ParalysisResistance : EditPacket
        {
            public ParalysisResistance(Character Character)
                : base(0x16, 2)
            {
                writer.Write(Character.Stats.ParalysisResistance);
            }
        }

        public class PUPoint : EditPacket
        {
            public PUPoint(Character Character)
                : base(0x17, 2)
            {
                writer.Write((ushort)Character.Player.StatPoints);
            }
        }

        public class SUPoint : EditPacket
        {
            public SUPoint(Character Character)
                : base(0x18, 2)
            {
                writer.Write((ushort)Character.Player.SkillPoints);
            }
        }

        
    }
}
