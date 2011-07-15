using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KalSharp.Worlds;

namespace KalSharp.Worlds.Stats
{
    public class EntityStats
    {
        public WorldEntity Entity;
        public EntityBaseStats BaseStats;

        public EntityStats(WorldEntity Entity, EntityBaseStats BaseStats)
        {
            this.Entity = Entity;
            this.BaseStats = BaseStats;
        }

        public ushort AttackSpeed
        {
            get
            {
                return (ushort)(BaseStats.AttackSpeed + Entity.Gear.AttackSpeed);
            }
        }

        public byte Strength
        {
            get
            {
                return (byte)(BaseStats.Strength + Entity.Gear.Strength);
            }
        }

        public byte Health
        {
            get
            {
                return (byte)(BaseStats.Health + Entity.Gear.Strength);
            }
        }

        public byte Intelligence
        {
            get
            {
                return (byte)(BaseStats.Intelligence + Entity.Gear.Intelligence);
            }
        }

        public byte Wisdom
        {
            get
            {
                return (byte)(BaseStats.Wisdom + Entity.Gear.Wisdom);
            }
        }

        public byte Dexterity
        {
            get
            {
                return (byte)(BaseStats.Dexterity + Entity.Gear.Dexterity);
            }
        }

        public ushort MaximumHP
        {
            get
            {
                return (ushort)(BaseStats.MaximumHP + Entity.Gear.MaximumHP);
            }
        }

        public ushort MaximumMP
        {
            get
            {
                return (ushort)(BaseStats.MaximumMP + Entity.Gear.MaximumMP);
            }
        }

        public ushort Evasion
        {
            get
            {
                return (ushort)(BaseStats.Evasion + Entity.Gear.Evasion);
            }
        }

        public ushort OTP
        {
            get
            {
                return (ushort)(BaseStats.OTP + Entity.Gear.OTP);
            }
        }

        public byte Absorb
        {
            get
            {
                return (byte)(BaseStats.Absorb + Entity.Gear.Absorb);
            }
        }

        public ushort MinDamage
        {
            get
            {
                return (ushort)(BaseStats.MinDamage + Entity.Gear.MinDamage);
            }
        }

        public ushort MaxDamage
        {
            get
            {
                return (ushort)(BaseStats.MaxDamage + Entity.Gear.MaxDamage);
            }
        }

        public ushort MinMagicalDamage
        {
            get
            {
                return (ushort)(BaseStats.MinMagicalDamage + Entity.Gear.MinMagicalDamage);
            }
        }

        public ushort MaxMagicalDamage
        {
            get
            {
                return (ushort)(BaseStats.MaxMagicalDamage + Entity.Gear.MaxMagicalDamage);
            }
        }

        public ushort Defense
        {
            get
            {
                return (ushort)(BaseStats.Defense + Entity.Gear.Defense);
            }
        }

        //resistances

        public ushort FireResistance
        {
            get
            {
                return (ushort)(BaseStats.FireResistance + Entity.Gear.FireResistance);
            }
        }

        public ushort IceResistance
        {
            get
            {
                return (ushort)(BaseStats.IceResistance + Entity.Gear.IceResistance);
            }
        }

        public ushort LightningResistance
        {
            get
            {
                return (ushort)(BaseStats.LightningResistance + Entity.Gear.LightningResistance);
            }
        }

        public ushort CurseResistance
        {
            get
            {
                return (ushort)(BaseStats.CurseResistance + Entity.Gear.CurseResistance);
            }
        }

        public ushort ParalysisResistance
        {
            get
            {
                return (ushort)(BaseStats.ParalysisResistance + Entity.Gear.ParalysisResistance);
            }
        }

    }
}
