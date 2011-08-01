using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KalSharp.Worlds.Npcs
{
    class Npc : WorldEntity
    {
        public int Shape;
        public int Index;

        public Npc(Vector3 Position, Vector2 Direction,int Index, int Shape)
        {
            this.Position = Position;
            this.Direction = Direction;
            this.Shape = Shape;
        }
    }
}
