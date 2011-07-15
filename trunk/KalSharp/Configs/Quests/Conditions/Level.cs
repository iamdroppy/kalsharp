using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KalSharp.Worlds.Characters;

namespace KalSharp.Configs.Quests.Conditions
{
    class Level : Condition
    {
        int MinLevel;

        public Level(int MinLevel)
        {
            this.MinLevel = MinLevel;
        }

        public override bool Check(Character Character)
        {
            if (Character.Player.Level >= MinLevel)
            {
                return true;
            }
            return false;
        }
    }
}
