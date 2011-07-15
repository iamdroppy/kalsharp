using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KalSharp.Worlds;
using KalSharp.Configs.InitItems;
using KalSharp.Packets;
using KalSharp.Translators;
using NHibernate;

namespace KalSharp.Worlds.Items
{
    public class Item
    {
        public virtual int PID { get; set; }
        public virtual int IID { get; set; }
        public virtual Int64 Index { get; set; }
        public virtual byte Prefix { get; set; }
        public virtual int Info { get; set; }
        public virtual int Num { get; set; }
        public virtual byte MaxEnd { get; set; }
        public virtual byte CurEnd { get; set; }
        public virtual byte SetGem { get; set; }
        public virtual byte XAttack { get; set; }
        public virtual byte XMagic { get; set; }
        public virtual byte XDefense { get; set; }
        public virtual byte XHit { get; set; }
        public virtual byte XDodge { get; set; }
        public virtual byte Protect { get; set; }
        public virtual byte UpgrLevel { get; set; }
        public virtual byte UpgrRate { get; set; }

        private InitItem inititem;

        public virtual InitItem InitItem
        {
            get
            {
                if (inititem == null)
                {
                    foreach (InitItem initItem in Configs.Config.InitItem)
                    {
                        if (initItem.Index == this.Index)
                        {
                            inititem = initItem;
                            return inititem;
                        }
                        
                    }
                    if (inititem == null)
                    {
                        ServerConsole.WriteLine("Unable to find inititem for index {0}", MessageLevel.Warning, this.Index);
                    }
                    return inititem;
                }
                else
                {
                    return inititem;
                }
            }
        }

        public static Item GetItem(int IID)
        {
            using (ISession session = Database.KalDB.OpenSession())
            {
                IQuery q = session.CreateQuery("FROM Item WHERE IID = :iid");
                q.SetParameter("iid", IID);
                return (Item)q.UniqueResult();
            }
        }

        public static int NextIID()
        {
            using (ISession session = Database.KalDB.OpenSession())
            {
                IQuery q = session.CreateQuery("FROM Item ORDER BY IID DESC");
                q.SetMaxResults(1);
                Item item = q.UniqueResult<Item>();
                return item.IID + 1;
            }
        }

        public virtual bool CanJoin(Item Item)
        {
            return (Index == Item.Index &&
                Prefix == Item.Prefix &&
                Info == Item.Info &&
                MaxEnd == Item.MaxEnd &&
                CurEnd == Item.CurEnd &&
                SetGem == Item.SetGem &&
                XAttack == Item.XAttack &&
                XMagic == Item.XMagic &&
                XDefense == Item.XDefense &&
                XHit == Item.XHit &&
                XDodge == Item.XDodge &&
                Protect == Item.Protect &&
                UpgrLevel == Item.UpgrLevel &&
                UpgrRate == Item.UpgrRate && InitItem.Plural == 1);
        }

        public virtual void Join(Item Item)
        {
            if (CanJoin(Item))
            {
                Num += Item.Num;
                Item.Num = 0;
                Database.Update(Database.KalDB, this);
            }
        }

        public virtual Item Copy()
        {
            Item newItem = new Item();
            newItem.IID = this.IID;
            newItem.PID = this.PID;
            newItem.Index = this.Index;
            newItem.Prefix = this.Prefix;
            newItem.Info = this.Info;
            newItem.Num = this.Num;
            newItem.MaxEnd = this.MaxEnd;
            newItem.CurEnd = this.CurEnd;
            newItem.SetGem = this.SetGem;
            newItem.XAttack = this.XAttack;
            newItem.XMagic = this.XMagic;
            newItem.XDefense = this.XDefense;
            newItem.XHit = this.XHit;
            newItem.XDodge = this.XDodge;
            newItem.Protect = this.Protect;
            newItem.UpgrLevel = this.UpgrLevel;
            newItem.UpgrRate = this.UpgrRate;

            return newItem;
        }

        public virtual Item Split(int Quantity)
        {
            if (this.Num > Quantity && Quantity > 0)
            {
                this.Num -= Quantity;

                Item newItem = new Item();
                newItem.IID = 0;
                newItem.PID = 0;
                newItem.Index = this.Index;
                newItem.Prefix = this.Prefix;
                newItem.Info = this.Info;
                newItem.Num = Quantity;
                newItem.MaxEnd = this.MaxEnd;
                newItem.CurEnd = this.CurEnd;
                newItem.SetGem = this.SetGem;
                newItem.XAttack = this.XAttack;
                newItem.XMagic = this.XMagic;
                newItem.XDefense = this.XDefense;
                newItem.XHit = this.XHit;
                newItem.XDodge = this.XDodge;
                newItem.Protect = this.Protect;
                newItem.UpgrLevel = this.UpgrLevel;
                newItem.UpgrRate = this.UpgrRate;

                Database.Update(Database.KalDB, this);

                return newItem;
            }
            else
            {
                throw new Exception("Unable to split item");
            }

        }
    }
}
