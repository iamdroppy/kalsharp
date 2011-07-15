using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KalSharp.Worlds.Items;

namespace KalSharp.Worlds.Drops
{
    public class Drop : WorldEntity
    {
        public Item Item;

        public Drop(Item Item, Vector3 Position)
        {
            this.Item = Item;
            
            this.Position.X = Position.X;
            this.Position.Y = Position.Y;
            this.Position.Z = Position.Z;

            ServerConsole.WriteLine("Created Drop");
        }
    }
}
