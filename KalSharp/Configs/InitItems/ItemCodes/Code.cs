using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KalSharp.Configs.InitItems.ItemCodes
{
    public enum PrimaryCode
    {
        None = 0,
        Weapon = 1,
        Clothing = 2,
        Applied = 3,
        General = 4,
        Jewelry = 5,
    }

    public enum SecondaryCode
    {
        None = 0,
        SingleHandedWeapon = 1,
        DualHandedWeapon = 2,
        Clothing = 3,
        Equipment = 4,
        HighTalisman = 5,
        LowTalisman = 6,
        Repair = 7,
        Consumable = 8,
        General = 9,
        Quest = 10,
        Money = 11,
        Unknown_12 = 12,
        Trinket = 13,
        Necklace = 14,
        Ring = 15,
    }

    public enum TertiaryCode
    {
        None = 0,
        Melee = 1,
        Ranged = 2,
        UpperArmor = 3,
        Helmet = 4,
        Gauntlet = 5,
        Boots = 6,
        LowerArmor = 7,
        Shield = 8,
        Mask = 9,
        Tast = 10,
        Transform = 11,
        TalismanIntensification = 12,
        TalismanProtection = 13,
        TalismanWonder = 14,
        TalismanAttack = 15,
        TalismanMagick = 16,
        TalismanDefence = 17,
        TalismanHit = 18,
        TalismanDodge = 19,
        Repair = 20,
        PolishStone = 21,
    }

    public enum QuaternaryCode
    {
        None = 0,
        Sword = 1,
        Bow = 2,
        Stick = 3,
    }

    public class Code
    {
        /// <summary>
        /// Primary Code.
        /// </summary>
        public PrimaryCode Primary;
        /// <summary>
        /// Secondary Code.
        /// </summary>
        public SecondaryCode Secondary;
        /// <summary>
        /// Tertiary Code.
        /// </summary>
        public TertiaryCode Tertiary;
        /// <summary>
        /// Quaternary Code.
        /// </summary>
        public QuaternaryCode Quaternary;

        /// <summary>
        /// Determins the type of item.
        /// </summary>
        /// <param name="Primary">Primary Code.</param>
        /// <param name="Secondary">Secondary Code.</param>
        /// <param name="Tertiary">Tertiary Code.</param>
        /// <param name="Quaternary">Quaternary Code.</param>
        public Code(PrimaryCode Primary, SecondaryCode Secondary, TertiaryCode Tertiary, QuaternaryCode Quaternary)
        {
            this.Primary = Primary;
            this.Secondary = Secondary;
            this.Tertiary = Tertiary;
            this.Quaternary = Quaternary;
        }

        public Code(int Primary, int Secondary, int Tertiary, int Quaternary)
        {
            this.Primary = (PrimaryCode)Primary;
            this.Secondary = (SecondaryCode)Secondary;
            this.Tertiary = (TertiaryCode)Tertiary;
            this.Quaternary = (QuaternaryCode)Quaternary;
        }
    }
}
