using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KalSharp.Worlds.Items
{
    public abstract class Gear
    {

        public abstract List<PlayerItem> EquippedItems { get; }
        public abstract Dictionary<int, ushort> Slots { get; }

        public byte Strength
        {
            get
            {
                byte Strength = 0x00;
                foreach (PlayerItem pItem in EquippedItems)
                {
                    Strength += pItem.Item.Specialty.Strength;
                }
                return Strength;
            }
        }

        public byte Health
        {
            get
            {
                byte Health = 0x00;
                foreach (PlayerItem pItem in EquippedItems)
                {
                    Health += pItem.Item.Specialty.Health;
                }
                return Health;
            }
        }

        public byte Intelligence
        {
            get
            {
                byte Intelligence = 0x00;
                foreach (PlayerItem pItem in EquippedItems)
                {
                    Intelligence += pItem.Item.Specialty.Intelligence;
                }
                return Intelligence;
            }
        }

        public byte Wisdom
        {
            get
            {
                byte Wisdom = 0x00;
                foreach (PlayerItem pItem in EquippedItems)
                {
                Wisdom += pItem.Item.Specialty.Intelligence;
                }
                return Wisdom;
            }
        }

        public byte Dexterity
        {
            get
            {
                byte Dexterity = 0x00;
                foreach (PlayerItem pItem in EquippedItems)
                {
                    Dexterity += pItem.Item.Specialty.Dexterity;
                }
                return Dexterity;
            }
        }

        public ushort MaximumHP
        {
            get
            {
                ushort MaximumHP = 0x00;
                foreach (PlayerItem pItem in EquippedItems)
                {
                    MaximumHP += pItem.Item.Specialty.HealthPoints;
                }
                return MaximumHP;
            }
        }

        public ushort MaximumMP
        {
            get
            {
                ushort MaximumMP = 0x00;
                foreach (PlayerItem pItem in EquippedItems)
                {
                    MaximumMP += pItem.Item.Specialty.MagicPoints;
                }
                return MaximumMP;
            }
        }

        public ushort Evasion
        {
            get
            {
                ushort Evasion = 0;
                foreach (PlayerItem pItem in EquippedItems)
                {
                    Evasion += pItem.Item.Specialty.Dodge;
                }
                return Evasion;
            }
        }

        public ushort OTP
        {
            get
            {
                ushort OTP = 0;
                foreach (PlayerItem pItem in EquippedItems)
                {
                    OTP += pItem.Item.Specialty.Hit;
                }
                return OTP;
            }
        }

        public byte Absorb
        {
            get
            {
                byte Absorb = 0x00;
                foreach (PlayerItem pItem in EquippedItems)
                {
                    Absorb += pItem.Item.Specialty.Absorb;
                }
                return Absorb;
            }
        }

        public ushort MinDamage
        {
            get
            {
                ushort MinDamage = 0;
                foreach (PlayerItem pItem in EquippedItems)
                {
                    if (pItem.Item.Specialty.Attack != null)
                    {
                        MinDamage += pItem.Item.Specialty.Attack.Min;
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
                foreach (PlayerItem pItem in EquippedItems)
                {
                    if (pItem.Item.Specialty.Attack != null)
                    {
                        MaxDamage += pItem.Item.Specialty.Attack.Max;
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
                foreach (PlayerItem pItem in EquippedItems)
                {
                    if (pItem.Item.Specialty.Magic != null)
                    {
                        MinMagicalDamage += pItem.Item.Specialty.Magic.Min;
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
                foreach (PlayerItem pItem in EquippedItems)
                {
                    if (pItem.Item.Specialty.Magic != null)
                    {
                        MaxMagicalDamage += pItem.Item.Specialty.Magic.Max;
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
                foreach (PlayerItem pItem in EquippedItems)
                {
                    Defense += pItem.Item.Specialty.Defense;
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
                foreach (PlayerItem pItem in EquippedItems)
                {
                    FireResistance += pItem.Item.Specialty.ResistFire;
                }
                return FireResistance;
            }
        }

        public ushort IceResistance
        {
            get
            {
                ushort IceResistance = 0;
                foreach (PlayerItem pItem in EquippedItems)
                {
                    IceResistance += pItem.Item.Specialty.ResistIce;
                }
                return IceResistance;
            }
        }

        public ushort LightningResistance
        {
            get
            {
                ushort LightningResistance = 0;
                foreach (PlayerItem pItem in EquippedItems)
                {
                    LightningResistance += pItem.Item.Specialty.ResistLightning;
                }
                return LightningResistance;
            }
        }

        public ushort CurseResistance
        {
            get
            {
                ushort CurseResistance = 0;
                foreach (PlayerItem pItem in EquippedItems)
                {
                    CurseResistance += pItem.Item.Specialty.ResistCurse;
                }
                return CurseResistance;
            }
        }

        public ushort ParalysisResistance
        {
            get
            {
                ushort ParalysisResistance = 0;
                foreach (PlayerItem pItem in EquippedItems)
                {
                    ParalysisResistance += pItem.Item.Specialty.ResistParalysis;
                }
                return ParalysisResistance;
            }
        }

        public ushort AttackSpeed
        {
            get
            {
                ushort AttackSpeed = 0;
                foreach (PlayerItem pItem in EquippedItems)
                {
                    AttackSpeed += pItem.Item.Specialty.AttackSpeed;
                }
                return AttackSpeed;
            }
        }
    }
}
