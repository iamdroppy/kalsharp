using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using KalSharp.Worlds.Characters;

namespace KalSharp.Worlds.Items
{
    public class Inventory
    {
        public Character Character;

        public Inventory(Character Character)
        {
            this.Character = Character;
        }

        public Item RemoveItem(Item Item, int Quantity)
        {

            if (Item.Num == Quantity || Item.InitItem.Plural != 1)
            {
                ServerConsole.WriteLine("No split");

                //remove item from database
                Database.Delete(Database.KalDB, Item);
                
                //inform the client we have removed the item
                Character.Client.Send(new Packets.RemoveFromInventory(Item.IID));
                //assign new iid and pid
                Item.IID = 0;
                Item.PID = 0;
                
                //return the item we removed
                return Item;
            }
            else
            {
                ServerConsole.WriteLine("Split");
                //split the item
                Item newItem = Item.Split(Quantity);
                Character.Client.Send(new Packets.SetItemQuantity(Item.IID, Item.Num));
                return newItem;
            }
        }

        public Item ContainsItemStack(Item Item, int Quantity)
        {
            lock (this)
            {
                foreach (Item item in Items)
                {
                    if (item.CanJoin(Item))
                    {
                        if(item.Num >= Quantity)
                        {
                            ServerConsole.WriteLine("Contains stack of item {0}", MessageLevel.Message, Item.Index);
                            return item;
                        }
                    }
                }
                return null;
            }
        }

        public void AddItem(Item Item)
        {
            //check if theres atleast 1 item the same in inventory
            Item currentStack = ContainsItemStack(Item, 1);
            if(currentStack != null)
            {
                //join items
                currentStack.Join(Item);
                Character.Client.Send(new Packets.SetItemQuantity(currentStack.IID, currentStack.Num));
            }
            else
            {
                //add new item
                Item.PID = Character.Player.PID;
                //check if it needs an iid
                if(Item.IID == 0)
                {
                    Item.IID = Item.NextIID();
                }
                ServerConsole.WriteLine("Added new item {0}", MessageLevel.Message, Item.IID);
                //save it
                Database.Save(Database.KalDB, Item);
                Character.Client.Send(new Packets.AddToInventory(Item));
            }
            
        }

        public void TransferItem(Item Item)
        {
            Item.PID = Character.Player.PID;
            Database.Update(Database.KalDB, Item);
        }

        public List<Item> Items
        {
            get
            {
                using (ISession session = Database.KalDB.OpenSession())
                {
                    IQuery q = session.CreateQuery("FROM Item WHERE PID = :pid");
                    q.SetParameter("pid", Character.Player.PID);
                    return (List<Item>)q.List<Item>();
                }
            }
        }
    }
}
