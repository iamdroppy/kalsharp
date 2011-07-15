using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KalSharp.Worlds.Stats
{
    public class EntityBaseStats
    {
        protected byte strength;
        protected byte health;
        protected byte intelligence;
        protected byte wisdom;
        protected byte dexterity;
        protected Int16 maximumHP;
        protected Int16 maximumMP;
        protected Int16 evasion;
        protected Int16 oTP;
        protected Int16 absorb;
        protected Int16 minDamage;
        protected Int16 maxDamage;
        protected Int16 minMagicalDamage;
        protected Int16 maxMagicalDamage;
        protected Int16 defense;
        protected Int16 attackSpeed;

        protected Int16 fireResistance;
        protected Int16 iceResistance;
        protected Int16 lightningResistance;
        protected Int16 curseResistance;
        protected Int16 paralysisResistance;

        public virtual byte Strength { get { return strength; } set { strength = value; } }
        public virtual byte Health { get { return health; } set { health = value; } }
        public virtual byte Intelligence { get { return intelligence; } set { intelligence = value; } }
        public virtual byte Wisdom { get { return wisdom; } set { wisdom = value; } }
        public virtual byte Dexterity { get { return dexterity; } set { dexterity = value; } }

        public virtual Int16 MaximumHP
        {
            get
            {
                return (Int16)(Health * 10);
            }
        }

        public virtual Int16 MaximumMP
        {
            get
            {
                return (Int16)(Wisdom * 10);
            }
        }

        public virtual Int16 Evasion { get { return evasion; } set { evasion = value; } }
        public virtual Int16 OTP { get { return oTP; } set { oTP = value; } }
        public virtual Int16 Absorb { get { return absorb; } set { absorb = value; } }
        public virtual Int16 MinDamage { get { return minDamage; } set { minDamage = value; } }
        public virtual Int16 MaxDamage { get { return maxDamage; } set { maxDamage = value; } }
        public virtual Int16 MinMagicalDamage { get { return minMagicalDamage; } set { minMagicalDamage = value; } }
        public virtual Int16 MaxMagicalDamage { get { return maxMagicalDamage; } set { maxMagicalDamage = value; } }
        public virtual Int16 Defense { get { return defense; } set { defense = value; } }
        public virtual Int16 AttackSpeed { get { return attackSpeed; } set { attackSpeed = value; } }

        public virtual Int16 FireResistance { get { return fireResistance; } set { fireResistance = value; } }
        public virtual Int16 IceResistance { get { return iceResistance; } set { iceResistance = value; } }
        public virtual Int16 LightningResistance { get { return lightningResistance; } set { lightningResistance = value; } }
        public virtual Int16 CurseResistance { get { return curseResistance; } set { curseResistance = value; } }
        public virtual Int16 ParalysisResistance { get { return paralysisResistance; } set { paralysisResistance = value; } }
    }
}
