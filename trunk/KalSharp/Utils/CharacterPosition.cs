using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KalSharp.Worlds.Characters;

namespace KalSharp
{
    class CharacterPosition : Vector3
    {
        Character Character;

        public CharacterPosition(Character Character):base()
        {
            this.Character = Character;
        }

        public override int X
        {
            get
            {
                return Character.Player.X;
            }
            set
            {
                Character.Player.X = value;
            }
        }

        public override int Y
        {
            get
            {
                return Character.Player.Y;
            }
            set
            {
                Character.Player.Y = value;
            }
        }

        public override int Z
        {
            get
            {
                return Character.Player.Z;
            }
            set
            {
                Character.Player.Z = value;
            }
        }

    }
}
