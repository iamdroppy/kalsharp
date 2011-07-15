using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KalSharp.Configs.InitItems.Specialties
{
    public class Specialty
    {
        /// <summary>
        /// Physical damage dealt on attack.
        /// </summary>
        public Attack Attack;
        /// <summary>
        /// Changes the prefix of another item when used.
        /// </summary>
        public ChangePrefix ChangePrefix;
        /// <summary>
        /// Adds dexterity when item is equipped.
        /// </summary>
        public byte Dexterity;
        /// <summary>
        /// Adds health when item is equipped.
        /// </summary>
        public byte Health;
        /// <summary>
        /// Intelligenced added when item is equipped.
        /// </summary>
        public byte Intelligence;
        /// <summary>
        /// Magic damage dealth on attack.
        /// </summary>
        public Magic Magic;
        /// <summary>
        /// Strenth added when item is equipped.
        /// </summary>
        public byte Strength;
        /// <summary>
        /// Wisdom added when item is equipped.
        /// </summary>
        public byte Wisdom;
        /// <summary>
        /// Absorbtion added when item is equipped.
        /// </summary>
        public byte Absorb;
        /// <summary>
        /// Delay between attacks in milliseconds.
        /// </summary>
        public ushort AttackSpeed;
        /// <summary>
        /// Buff given to player when item is used.
        /// </summary>
        public Buff Buff;
        /// <summary>
        /// Charming done when used on an item.
        /// </summary>
        public Charming Charming;
        /// <summary>
        /// Defense added when item is equipped.
        /// </summary>
        public ushort Defense;
        /// <summary>
        /// Increases the players dodge chance when item is equipped.
        /// </summary>
        public ushort Dodge;
        /// <summary>
        /// GState given to player when item is used.
        /// </summary>
        public GState GState;
        /// <summary>
        /// Hit (OTP) added when item is equipped.
        /// </summary>
        public ushort Hit;
        /// <summary>
        /// Health points added when item is equipped.
        /// </summary>
        public ushort HealthPoints;
        /// <summary>
        /// Magic points added when item is equipped.
        /// </summary>
        public ushort MagicPoints;
        /// <summary>
        /// Move speed added when item is equipped.
        /// </summary>
        public MoveSpeed MoveSpeed;
        /// <summary>
        /// 
        /// </summary>
        public bool Protect;
        /// <summary>
        /// Refreshing done when item is used.
        /// </summary>
        public Refresh Refresh;
        /// <summary>
        /// Item can be used to repair.
        /// </summary>
        public int Repair;
        /// <summary>
        /// Curse resistance added when item is equipped.
        /// </summary>
        public ushort ResistCurse;
        /// <summary>
        /// Fire resistance added when item is equipped.
        /// </summary>
        public ushort ResistFire;
        /// <summary>
        /// Ice resistance added when item is equipped.
        /// </summary>
        public ushort ResistIce;
        /// <summary>
        /// Lightning resistance added when item is equipped.
        /// </summary>
        public ushort ResistLightning;
        /// <summary>
        /// Paralysis resistance added when item is equipped.
        /// </summary>
        public ushort ResistParalysis;
        /// <summary>
        /// Exp percent lost on revival.
        /// </summary>
        public ushort Revival;
        /// <summary>
        /// Teleports the user(s) when item is used.
        /// </summary>
        public Teleport Teleport;
    }
}
