using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KalSharp.Worlds;
using KalSharp.Worlds.Items;
using KalSharp.Translators;
using KalSharp.Packets;
using KalSharp.Worlds.Drops;
using KalSharp.Worlds.Characters;

namespace KalSharp.Configs.InitItems.ItemCodes.Handlers
{
    public class CodeHandler
    {
        public Code Code;

        public CodeHandler(Code Code)
        {
            this.Code = Code;
        }

        public bool MatchesCode(Code Code)
        {
            if (Code.Primary == this.Code.Primary)
            {
                if (Code.Secondary == this.Code.Secondary)
                {
                    if (Code.Tertiary == this.Code.Tertiary)
                    {
                        if (Code.Quaternary == this.Code.Quaternary)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        protected virtual bool CheckLimit(Item Item, Character Character)
        {
            if (Character.Player.Class == Item.InitItem.Limit.Class)
            {
                if (Character.Player.Level >= Item.InitItem.Limit.Level)
                {
                    return true;
                }
            }
            return false;
        }

        public void Equip(Item Item, WorldEntity Entity, Client Client)
        {
            if (CheckLimit(Item, Client.Character))
            {
                OnEquip(Item, Entity, Client);
            }
            Client.Character.UpdateStats();
        }

        public void Unequip(Item Item, WorldEntity Entity, Client Client)
        {
            OnUnequip(Item, Entity, Client);
            Client.Character.UpdateStats();
        }

        public void Drop(Item Item, int Quantity, WorldEntity Entity, Client Client)
        {
            //todo check for bound items
            OnDrop(Item, Quantity, Entity, Client);
        }

        public void Pickup(Drop Drop, WorldEntity Entity, Client Client)
        {
            //todo check ownership
            DoPickup(Drop, Entity, Client);
        }


        protected virtual void OnEquip(Item Item, WorldEntity Entity, Client Client)
        {
            DoEquip(Item, Entity, Client);
        }

        protected virtual void OnUnequip(Item Item, WorldEntity Entity, Client Client)
        {
            DoUnequip(Item, Entity, Client);
        }

        protected virtual void OnDrop(Item Item, int Quantity, WorldEntity Entity, Client Client)
        {
            DoDrop(Item, Quantity, Entity, Client);
        }

        protected virtual void OnPickup(Drop Drop, WorldEntity Entity, Client Client)
        {
            DoPickup(Drop, Entity, Client);
        }

        protected void DoDrop(Item Item, int Quantity, WorldEntity Entity, Client Client)
        {
            //check if the player has the available quantity
            if (Item.Num >= Quantity && Quantity > 0)
            {
                ServerConsole.WriteLine("DOing the drop");
                Random r = new Random();
                Vector3 pos = new Vector3(Entity.Position.X + r.Next(-32, 32), Entity.Position.Y + r.Next(-32, 32), Entity.Position.Z);
                
                Item removedItem = Client.Character.Inventory.RemoveItem(Item, Quantity);
                Drop drop = new Drop(removedItem, pos);

                ServerWorld.AddEntity(drop);
            }
            else
            {
                Hackshield.AddOffense(Client, OffenseSeverity.IncorrectPacketDetails);
            }

           
        }

        protected void DoPickup(Drop Drop, WorldEntity Entity, Client Client)
        {
            Item Item = Drop.Item;
            //add to inventory
            Client.Character.Inventory.AddItem(Item);
            Client.Send(new Packets.PickupDrop(Drop.WorldId));
            ServerWorld.RemoveEntity(Drop);

            Client.Character.UpdateEntitiesInView(true);
        }

        protected void DoEquip(Item Item, WorldEntity Entity, Client Client)
        {
            Item.Info += 1;
            Database.Update(Database.KalDB, Item);
            Client.Send(new Packets.EquipItem(Item, Entity));
        }

        protected void DoUnequip(Item Item, WorldEntity Entity, Client Client)
        {
            Item.Info -= 1;
            Database.Update(Database.KalDB, Item);
            Client.Send(new Packets.UnequipItem(Item, Entity));
        }
    }
}
