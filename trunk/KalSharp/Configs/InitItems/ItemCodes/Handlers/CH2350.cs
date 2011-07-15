using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KalSharp.Worlds;
using KalSharp.Worlds.Items;
using KalSharp.Translators;
using KalSharp.Packets;
using KalSharp.Worlds.Drops;

namespace KalSharp.Configs.InitItems.ItemCodes.Handlers
{
    class CH2350 : CodeHandler
    {
        public CH2350() : base(new Code(PrimaryCode.Clothing, SecondaryCode.Clothing, TertiaryCode.Gauntlet, QuaternaryCode.None)) { }

        protected override void OnEquip(Item Item, WorldEntity Entity, Client Client)
        {
            DoEquip(Item, Entity, Client);
        }

        protected override void OnUnequip(Item Item, WorldEntity Entity, Client Client)
        {
            DoUnequip(Item, Entity, Client);
        }
    }
}
