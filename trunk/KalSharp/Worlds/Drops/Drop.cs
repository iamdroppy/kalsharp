using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KalSharp.Worlds.Items;

namespace KalSharp.Worlds.Drops
{
    public class Drop : WorldEntity
    {
        public PlayerItem PlayerItem;

        public Drop(PlayerItem PlayerItem, Vector3 Position)
        {
            this.PlayerItem = PlayerItem;
            
            this.Position.X = Position.X;
            this.Position.Y = Position.Y;
            this.Position.Z = Position.Z;
        }
    }
}
