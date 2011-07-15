using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KalSharp.Worlds.Characters;

namespace KalSharp.Configs.Quests
{
    public abstract class Action
    {
        public abstract void Execute(Character Character);
    }
}
