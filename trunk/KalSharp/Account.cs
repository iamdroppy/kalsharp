using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KalSharp.Worlds.Characters;
using KalSharp.Worlds.Items;
using System.Data;
using NHibernate;
using NHibernate.Cfg;

namespace KalSharp
{
    public class Account
    {
        private ISession session;
        ////Database properties
        //private int uid;
        //private string id;
        //private byte[] password;
        //private byte type;
        //private int expTime;
        //private int info;
        //private DateTime birthDate;

        //other properties
        private Client client;
        private Inventory storage;
        private Character character;

        #region Properties

        public virtual int UID { get; set; }
        public virtual string ID { get; set; }
        public virtual byte[] Password { get; set; }
        public virtual byte Type { get; set; }
        public virtual int ExpTime { get; set; }
        public virtual int Info { get; set; }
        public virtual DateTime BirthDate { get; set; }

        #endregion Properties

        public virtual bool IsBlocked
        {
            get
            {
                if (Info == 10)
                {
                    return true;
                }
                return false;
            }
        }

        public virtual IList<Player> Players
        {
            get
            {
                List<Player> playerList = new List<Player>();
                using (session = Database.KalDB.OpenSession())
                {
                    IQuery q = session.CreateQuery("FROM Player WHERE UID = :UID ORDER BY PID ASC");
                    q.SetParameter("UID", this.UID);

                    return q.List<Player>();
                }
            }
        }

        public virtual IList<PlayerDeleted> DeletedPlayerList
        {
            get
            {
                using (session = Database.KalDB.OpenSession())
                {
                    IQuery q = session.CreateQuery("FROM PlayerDeleted WHERE UID = :UID");
                    q.SetParameter("UID", this.UID);

                    return q.List<PlayerDeleted>();
                }
            }
        }

        public virtual IList<Player> DeletedPlayers
        {
            get
            {
                IList<PlayerDeleted> deletedPlayerList = DeletedPlayerList;
                IList<Player> deletedPlayers = new List<Player>();

                using (session = Database.KalDB.OpenSession())
                {
                    foreach (PlayerDeleted pDel in deletedPlayerList)
                    {
                        IQuery q = session.CreateQuery("FROM Player WHERE PID = :PID ORDER BY PID DESC");
                        q.SetParameter("PID", pDel.PID);

                        deletedPlayers.Add(q.UniqueResult<Player>());
                    }
                }

                return deletedPlayers;
            }
        }

        public virtual Client Client
        {
            get
            {
                return client;
            }
            set
            {
                client = value;
            }
        }

        public virtual Character Character
        {
            get
            {
                return character;
            }
            set
            {
                this.character = value;
            }
        }

        public virtual Inventory Storage
        {
            get
            {
                return storage;
            }
        }

        public virtual string DecodedPassword
        {
            get
            {
                return Utilities.DecodePassword(Password);
            }
        }
    }
}



//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using KalSharp.Worlds.Characters;
//using KalSharp.Worlds.Items;
//using System.Data;

//namespace KalSharp
//{
//    public class Account
//    {
//        ////Database properties
//        //private int uid;
//        //private string id;
//        //private byte[] password;
//        //private byte type;
//        //private int expTime;
//        //private int info;
//        //private DateTime birthDate;

//        //other properties
//        private Client client;
//        private Inventory storage;
//        private Character character;

//        #region Properties

//        public virtual int UID
//        {
//            get { return uid; }
//            set { uid = value; }
//        }

//        public virtual string ID
//        {
//            get { return id; }
//            set { id = value; }
//        }

//        public virtual byte[] Password
//        {
//            get { return password; }
//            set { password = value; }
//        }

//        public virtual byte Type
//        {
//            get { return type; }
//            set { type = value; }
//        }

//        public virtual int ExpTime
//        {
//            get { return expTime; }
//            set { expTime = value; }
//        }

//        public virtual int Info
//        {
//            get { return info; }
//            set { info = value; }
//        }

//        public virtual DateTime BirthDate
//        {
//            get { return birthDate; }
//            set { birthDate = value; }
//        }
//        #endregion Properties

//        public virtual bool IsBlocked
//        {
//            get
//            {
//                if (Info == 10)
//                {
//                    return true;
//                }
//                return false;
//            }
//        }

//        public virtual List<Player> Players
//        {
//            get
//            {
//                return new List<Player>();
//            }
//        }

//        public virtual Client Client
//        {
//            get
//            {
//                return client;
//            }
//            set
//            {
//                client = value;
//            }
//        }

//        public virtual Character Character
//        {
//            get
//            {
//                return character;
//            }
//            set
//            {
//                this.character = value;
//            }
//        }

//        public virtual Inventory Storage
//        {
//            get
//            {
//                return storage;
//            }
//        }

//        public virtual string DecodedPassword
//        {
//            get
//            {
//                return Utilities.DecodePassword(Password);
//            }
//        }
//    }
//}
