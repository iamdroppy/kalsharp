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
    class CH1222 : CodeHandler
    {
        public CH1222() : base(new Code(PrimaryCode.Weapon, SecondaryCode.DualHandedWeapon, TertiaryCode.Ranged, QuaternaryCode.Bow)) { }

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
