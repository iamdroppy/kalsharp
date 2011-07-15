using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;



namespace KalSharp.Worlds.Npcs
{
    public abstract class Npc : WorldEntity
    {
        public int Index;
        public int Kind;
        public int Shape;
        public int Map;

        public abstract void Use(Player Player);
    }
}
