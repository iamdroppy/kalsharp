using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;

namespace KalSharp
{
    public partial class Client
    {
        /// <summary>
        /// Creates a Character
        /// </summary>
        /// <param name="name">Character Name</param>
        /// <param name="classId">Class</param>
        /// <param name="strength">Strength</param>
        /// <param name="health">Health</param>
        /// <param name="intelligence">Intelligence</param>
        /// <param name="wisdom">Wisdom</param>
        /// <param name="agility">Agility</param>
        /// <param name="face">Face Style</param>
        /// <param name="hair">Hair Style</param>
        public int CreatePlayer(string Name, int Class, int Strength, int Health, int Intelligence, int Wisdom, int Dexterity, int Face, int Hair)
        {
            ServerConsole.WriteLine("Creating character called {0} for {1}.", MessageLevel.Message, Name, Account.ID);

            ///
            /// Configure the stats correctly foreach class
            /// 
            switch (Class)
            {
                case 0:
                    Strength += 18;
                    Health += 16;
                    Intelligence += 8;
                    Wisdom += 8;
                    Dexterity += 10;
                    break;
                case 1:
                    Strength += 8;
                    Health += 10;
                    Intelligence += 18;
                    Wisdom += 16;
                    Dexterity += 8;
                    break;
                case 2:
                    Strength += 14;
                    Health += 10;
                    Intelligence += 8;
                    Wisdom += 10;
                    Dexterity += 18;
                    break;
            }

            //create player
            Player p;
            using (session = Database.KalDB.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    p = new Player();
                    p.UID = Account.UID;
                    p.Name = Name;
                    p.Class = (byte)Class;
                    p.Level = 1;
                    p.Specialty = 0;
                    p.Strength = (byte)Strength;
                    p.Health = (byte)Health;
                    p.Intelligence = (byte)Intelligence;
                    p.Wisdom = (byte)Wisdom;
                    p.Dexterity = (byte)Dexterity;
                    p.Face = (byte)Face;
                    p.Hair = (byte)Hair;
                    p.X = 257491;
                    p.Y = 258584;
                    p.Z = 16120;

                    session.Save(p);
                    transaction.Commit();
                }
            }
            return p.PID;
        }

        public void DeletePlayer(int PID)
        {
            ServerConsole.WriteLine("Deleteing player {0}", MessageLevel.Message, PID);
            Player p = Player.GetPlayer(PID);
            //set uid to 0 to show player deleted.
            p.UID = 0;
            Database.Update(Database.KalDB, p);

            using (session = Database.KalDB.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    PlayerDeleted pd = new PlayerDeleted();
                    pd.PID = PID;
                    pd.UID = Account.UID;
                    pd.DeletedTime = DateTime.Now;

                    session.Save(pd);
                    transaction.Commit();
                }
            }
        }

        public void RestorePlayer(int PID)
        {
            //delete from player deleted
            PlayerDeleted pd = PlayerDeleted.GetPlayerDeleted(PID);
            Database.Delete(Database.KalDB, pd);
            //set uid
            Player p = Player.GetPlayer(PID);
            p.UID = Account.UID;
            Database.Update(Database.KalDB, p);
        }
    }
}
