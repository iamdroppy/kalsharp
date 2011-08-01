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

        public PlayerItem RemoveItem(PlayerItem PlayerItem, int Quantity)
        {

            if (PlayerItem.Num == Quantity || PlayerItem.Item.Plural != 1)
            {
                ServerConsole.WriteLine("No split");

                //remove item from database
                Database.Delete(Database.KalDB, PlayerItem);
                
                //inform the client we have removed the item
                Character.Client.Send(new Packets.RemoveFromInventory(PlayerItem.IID));
                //assign new iid and pid
                PlayerItem.IID = 0;
                PlayerItem.PID = 0;
                
                //return the item we removed
                return PlayerItem;
            }
            else
            {
                ServerConsole.WriteLine("Split");
                //split the item
                PlayerItem newItem = PlayerItem.Split(Quantity);
                Character.Client.Send(new Packets.SetItemQuantity(PlayerItem.IID, PlayerItem.Num));
                return newItem;
            }
        }

        public PlayerItem ContainsItemStack(PlayerItem PlayerItem, int Quantity)
        {
            lock (this)
            {
                foreach (PlayerItem pitem in Items)
                {
                    if (pitem.CanJoin(PlayerItem))
                    {
                        if(pitem.Num >= Quantity)
                        {
                            ServerConsole.WriteLine("Contains stack of item {0}", MessageLevel.Message, PlayerItem.Index);
                            return pitem;
                        }
                    }
                }
                return null;
            }
        }

        public void AddItem(PlayerItem PlayerItem)
        {
            //check if theres atleast 1 item the same in inventory
            PlayerItem currentStack = ContainsItemStack(PlayerItem, 1);
            if(currentStack != null)
            {
                //join items
                currentStack.Join(PlayerItem);
                Character.Client.Send(new Packets.SetItemQuantity(currentStack.IID, currentStack.Num));
            }
            else
            {
                //add new item
                PlayerItem.PID = Character.Player.PID;
                //check if it needs an iid
                if(PlayerItem.IID == 0)
                {
                    PlayerItem.IID = PlayerItem.NextIID();
                }
                ServerConsole.WriteLine("Added new item {0}", MessageLevel.Message, PlayerItem.IID);
                //save it
                Database.Save(Database.KalDB, PlayerItem);
                Character.Client.Send(new Packets.AddToInventory(PlayerItem));
            }
            
        }

        public void TransferItem(PlayerItem PlayerItem)
        {
            PlayerItem.PID = Character.Player.PID;
            Database.Update(Database.KalDB, PlayerItem);
        }

        public List<PlayerItem> Items
        {
            get
            {
                using (ISession session = Database.KalDB.OpenSession())
                {
                    IQuery q = session.CreateQuery("FROM PlayerItem WHERE PID = :pid");
                    q.SetParameter("pid", Character.Player.PID);
                    return (List<PlayerItem>)q.List<PlayerItem>();
                }
            }
        }
    }
}
