using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KalSharp.Worlds.Characters;

namespace KalSharp.Worlds.Stats
{
    class CharacterBaseStats : EntityBaseStats
    {
        public Character Character;

        public CharacterBaseStats(Character Character)
        {
            this.Character = Character;
        }

        public override byte Strength
        {
            get
            {
                return Character.Player.Strength;
            }
            set
            {
                Character.Player.Strength = value;
            }
        }

        public override byte Health
        {
            get
            {
                return Character.Player.Health;
            }
            set
            {
                Character.Player.Health = value;
            }
        }

        public override byte Intelligence
        {
            get
            {
                return Character.Player.Intelligence;
            }
            set
            {
                Character.Player.Intelligence = value;
            }
        }

        public override byte Wisdom
        {
            get
            {
                return Character.Player.Wisdom;
            }
            set
            {
                Character.Player.Wisdom = value;
            }
        }

        public override byte Dexterity
        {
            get
            {
                return Character.Player.Dexterity;
            }
            set
            {
                Character.Player.Dexterity = value;
            }
        }
    }
}
