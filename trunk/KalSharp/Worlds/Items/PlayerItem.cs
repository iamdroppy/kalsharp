using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KalSharp.Worlds;
using KalSharp.Configs.Items;
using KalSharp.Packets;
using KalSharp.Translators;
using NHibernate;

namespace KalSharp.Worlds.Items
{
    public class PlayerItem
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

        private Item item;

        public virtual Item Item
        {
            get
            {
                if (item == null)
                {
   
                    item = Configs.Items.Item.FindByIndex(this.Index);

                    if (item == null)
                    {
                        ServerConsole.WriteLine("Unable to find inititem for index {0}", MessageLevel.Error, this.Index);
                    }
                    return item;
                }
                else
                {
                    return item;
                }
            }
        }

        public static PlayerItem GetItem(int IID)
        {
            using (ISession session = Database.KalDB.OpenSession())
            {
                IQuery q = session.CreateQuery("FROM PlayerItem WHERE IID = :iid");
                q.SetParameter("iid", IID);
                return (PlayerItem)q.UniqueResult();
            }
        }

        public static int NextIID()
        {
            using (ISession session = Database.KalDB.OpenSession())
            {
                IQuery q = session.CreateQuery("FROM PlayerItem ORDER BY IID DESC");
                q.SetMaxResults(1);
                PlayerItem pItem = q.UniqueResult<PlayerItem>();
                return pItem.IID + 1;
            }
        }

        public virtual bool CanJoin(PlayerItem PlayerItem)
        {
            return (Index == PlayerItem.Index &&
                Prefix == PlayerItem.Prefix &&
                Info == PlayerItem.Info &&
                MaxEnd == PlayerItem.MaxEnd &&
                CurEnd == PlayerItem.CurEnd &&
                SetGem == PlayerItem.SetGem &&
                XAttack == PlayerItem.XAttack &&
                XMagic == PlayerItem.XMagic &&
                XDefense == PlayerItem.XDefense &&
                XHit == PlayerItem.XHit &&
                XDodge == PlayerItem.XDodge &&
                Protect == PlayerItem.Protect &&
                UpgrLevel == PlayerItem.UpgrLevel &&
                UpgrRate == PlayerItem.UpgrRate && PlayerItem.Item.Plural == 1);
        }

        public virtual void Join(PlayerItem PlayerItem)
        {
            if (CanJoin(PlayerItem))
            {
                Num += PlayerItem.Num;
                PlayerItem.Num = 0;
                Database.Update(Database.KalDB, this);
            }
        }

        public virtual PlayerItem Copy()
        {
            PlayerItem newPlayerItem = new PlayerItem();
            newPlayerItem.IID = this.IID;
            newPlayerItem.PID = this.PID;
            newPlayerItem.Index = this.Index;
            newPlayerItem.Prefix = this.Prefix;
            newPlayerItem.Info = this.Info;
            newPlayerItem.Num = this.Num;
            newPlayerItem.MaxEnd = this.MaxEnd;
            newPlayerItem.CurEnd = this.CurEnd;
            newPlayerItem.SetGem = this.SetGem;
            newPlayerItem.XAttack = this.XAttack;
            newPlayerItem.XMagic = this.XMagic;
            newPlayerItem.XDefense = this.XDefense;
            newPlayerItem.XHit = this.XHit;
            newPlayerItem.XDodge = this.XDodge;
            newPlayerItem.Protect = this.Protect;
            newPlayerItem.UpgrLevel = this.UpgrLevel;
            newPlayerItem.UpgrRate = this.UpgrRate;

            return newPlayerItem;
        }

        public virtual PlayerItem Split(int Quantity)
        {
            if (this.Num > Quantity && Quantity > 0)
            {
                this.Num -= Quantity;

                PlayerItem newPlayerItem = new PlayerItem();
                newPlayerItem.IID = 0;
                newPlayerItem.PID = 0;
                newPlayerItem.Index = this.Index;
                newPlayerItem.Prefix = this.Prefix;
                newPlayerItem.Info = this.Info;
                newPlayerItem.Num = Quantity;
                newPlayerItem.MaxEnd = this.MaxEnd;
                newPlayerItem.CurEnd = this.CurEnd;
                newPlayerItem.SetGem = this.SetGem;
                newPlayerItem.XAttack = this.XAttack;
                newPlayerItem.XMagic = this.XMagic;
                newPlayerItem.XDefense = this.XDefense;
                newPlayerItem.XHit = this.XHit;
                newPlayerItem.XDodge = this.XDodge;
                newPlayerItem.Protect = this.Protect;
                newPlayerItem.UpgrLevel = this.UpgrLevel;
                newPlayerItem.UpgrRate = this.UpgrRate;

                Database.Update(Database.KalDB, this);

                return newPlayerItem;
            }
            else
            {
                throw new Exception("Unable to split item");
            }

        }
    }
}
