using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KalSharp.Worlds.Items
{
    public abstract class Gear
    {

        public abstract List<Item> EquippedItems { get; }
        public abstract Dictionary<int, ushort> Slots { get; }

        public byte Strength
        {
            get
            {
                byte Strength = 0x00;
                foreach (Item item in EquippedItems)
                {
                    Strength += item.InitItem.Specialty.Strength;
                }
                return Strength;
            }
        }

        public byte Health
        {
            get
            {
                byte Health = 0x00;
                foreach (Item item in EquippedItems)
                {
                    Health += item.InitItem.Specialty.Health;
                }
                return Health;
            }
        }

        public byte Intelligence
        {
            get
            {
                byte Intelligence = 0x00;
                foreach (Item item in EquippedItems)
                {
                    Intelligence += item.InitItem.Specialty.Intelligence;
                }
                return Intelligence;
            }
        }

        public byte Wisdom
        {
            get
            {
                byte Wisdom = 0x00;
                foreach (Item item in EquippedItems)
                {
                Wisdom += item.InitItem.Specialty.Intelligence;
                }
                return Wisdom;
            }
        }

        public byte Dexterity
        {
            get
            {
                byte Dexterity = 0x00;
                foreach (Item item in EquippedItems)
                {
                    Dexterity += item.InitItem.Specialty.Dexterity;
                }
                return Dexterity;
            }
        }

        public ushort MaximumHP
        {
            get
            {
                ushort MaximumHP = 0x00;
                foreach (Item item in EquippedItems)
                {
                    MaximumHP += item.InitItem.Specialty.HealthPoints;
                }
                return MaximumHP;
            }
        }

        public ushort MaximumMP
        {
            get
            {
                ushort MaximumMP = 0x00;
                foreach (Item item in EquippedItems)
                {
                    MaximumMP += item.InitItem.Specialty.MagicPoints;
                }
                return MaximumMP;
            }
        }

        public ushort Evasion
        {
            get
            {
                ushort Evasion = 0;
                foreach (Item item in EquippedItems)
                {
                    Evasion += item.InitItem.Specialty.Dodge;
                }
                return Evasion;
            }
        }

        public ushort OTP
        {
            get
            {
                ushort OTP = 0;
                foreach (Item item in EquippedItems)
                {
                    OTP += item.InitItem.Specialty.Hit;
                }
                return OTP;
            }
        }

        public byte Absorb
        {
            get
            {
                byte Absorb = 0x00;
                foreach (Item item in EquippedItems)
                {
                    Absorb += item.InitItem.Specialty.Absorb;
                }
                return Absorb;
            }
        }

        public ushort MinDamage
        {
            get
            {
                ushort MinDamage = 0;
                foreach (Item item in EquippedItems)
                {
                    if (item.InitItem.Specialty.Attack != null)
                    {
                        MinDamage += item.InitItem.Specialty.Attack.Min;
                    }
                }
                return MinDamage;
            }
        }

        public ushort MaxDamage
        {
            get
            {
                ushort MaxDamage = 0;
                foreach (Item item in EquippedItems)
                {
                    if (item.InitItem.Specialty.Attack != null)
                    {
                        MaxDamage += item.InitItem.Specialty.Attack.Max;
                    }
                }
                return MaxDamage;
            }
        }

        public ushort MinMagicalDamage
        {
            get
            {
                ushort MinMagicalDamage = 0;
                foreach (Item item in EquippedItems)
                {
                    if (item.InitItem.Specialty.Magic != null)
                    {
                        MinMagicalDamage += item.InitItem.Specialty.Magic.Min;
                    }
                }
                return MinMagicalDamage;
            }
        }

        public ushort MaxMagicalDamage
        {
            get
            {
                ushort MaxMagicalDamage = 0;
                foreach (Item item in EquippedItems)
                {
                    if (item.InitItem.Specialty.Magic != null)
                    {
                        MaxMagicalDamage += item.InitItem.Specialty.Magic.Max;
                    }
                }
                return MaxMagicalDamage;
            }
        }

        public ushort Defense
        {
            get
            {
                ushort Defense = 0;
                foreach (Item item in EquippedItems)
                {
                    Defense += item.InitItem.Specialty.Defense;
                }
                return Defense;
            }
        }

        //resistances

        public ushort FireResistance
        {
            get
            {
                ushort FireResistance = 0;
                foreach (Item item in EquippedItems)
                {
                    FireResistance += item.InitItem.Specialty.ResistFire;
                }
                return FireResistance;
            }
        }

        public ushort IceResistance
        {
            get
            {
                ushort IceResistance = 0;
                foreach (Item item in EquippedItems)
                {
                    IceResistance += item.InitItem.Specialty.ResistIce;
                }
                return IceResistance;
            }
        }

        public ushort LightningResistance
        {
            get
            {
                ushort LightningResistance = 0;
                foreach (Item item in EquippedItems)
                {
                    LightningResistance += item.InitItem.Specialty.ResistLightning;
                }
                return LightningResistance;
            }
        }

        public ushort CurseResistance
        {
            get
            {
                ushort CurseResistance = 0;
                foreach (Item item in EquippedItems)
                {
                    CurseResistance += item.InitItem.Specialty.ResistCurse;
                }
                return CurseResistance;
            }
        }

        public ushort ParalysisResistance
        {
            get
            {
                ushort ParalysisResistance = 0;
                foreach (Item item in EquippedItems)
                {
                    ParalysisResistance += item.InitItem.Specialty.ResistParalysis;
                }
                return ParalysisResistance;
            }
        }

        public ushort AttackSpeed
        {
            get
            {
                ushort AttackSpeed = 0;
                foreach (Item item in EquippedItems)
                {
                    AttackSpeed += item.InitItem.Specialty.AttackSpeed;
                }
                return AttackSpeed;
            }
        }
    }
}
