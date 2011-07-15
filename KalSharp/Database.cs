using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;

namespace KalSharp
{
    public static class Database
    {
        public static ISessionFactory KalAuth;
        public static ISessionFactory KalDB;

        public static void Connect()
        {
            ServerConsole.WriteLine("Database connecting...", MessageLevel.ODBC);

            //create config
            ServerConsole.WriteLine("Connecting to KalAuth...", MessageLevel.ODBC);
            Configuration cfg = new Configuration().Configure("kalauth.cfg.xml");

            //load resources
            ServerConsole.WriteLine("Loading resources", MessageLevel.ODBC);
            cfg.AddResource(@"KalSharp.Account.hbm.xml", System.Reflection.Assembly.GetExecutingAssembly());

            //building config
            KalAuth = cfg.BuildSessionFactory();
            ServerConsole.WriteLine("Connected to KalAuth", MessageLevel.ODBC);



            //create config
            ServerConsole.WriteLine("Connecting to KalDB...", MessageLevel.ODBC);
            Configuration cfg2 = new Configuration().Configure("kaldb.cfg.xml");

            //load resources
            ServerConsole.WriteLine("Loading resources", MessageLevel.ODBC);
            cfg2.AddResource(@"KalSharp.Player.hbm.xml", System.Reflection.Assembly.GetExecutingAssembly());
            cfg2.AddResource(@"KalSharp.PlayerDeleted.hbm.xml", System.Reflection.Assembly.GetExecutingAssembly());
            cfg2.AddResource(@"KalSharp.Worlds.Items.Item.hbm.xml", System.Reflection.Assembly.GetExecutingAssembly());

            //building config
            KalDB = cfg2.BuildSessionFactory();
            ServerConsole.WriteLine("Connected to KalDB", MessageLevel.ODBC);
        }


        public static void Save(ISessionFactory Database, object Object)
        {
            using (ISession session = Database.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(Object);
                    transaction.Commit();
                }
            }
        }

        public static void Update(ISessionFactory Database, object Object)
        {
            using (ISession session = Database.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(Object);
                    transaction.Commit();
                }
            }
        }


        public static void Delete(ISessionFactory Database, object Object)
        {
            using (ISession session = Database.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(Object);
                    transaction.Commit();
                }
            }
        }
    }
}
