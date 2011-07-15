using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KalSharp.Worlds.Characters;

namespace KalSharp.Configs.Quests
{
    public abstract class Condition
    {
        public abstract bool Check(Character Character);
    }
}
