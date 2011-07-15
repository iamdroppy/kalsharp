using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace KalSharp
{
    public class PlayerDeleted
    {
        public virtual int PID { get; set; }
        public virtual int UID { get; set; }
        public virtual DateTime DeletedTime { get; set; }

        private Player player;

        public virtual Player Player
        {
            get
            {
                if (player == null)
                {
                    using (ISession session = Database.KalDB.OpenSession())
                    {
                        IQuery q = session.CreateQuery("FROM Player WHERE PID = :pid");
                        q.SetParameter("pid", this.PID);
                        player = q.UniqueResult<Player>();
                        return player;
                    }
                }
                else
                {
                    return player;
                }
            }
        }

        public static PlayerDeleted GetPlayerDeleted(int PID)
        {
            using (ISession session = Database.KalDB.OpenSession())
            {
                IQuery q = session.CreateQuery("FROM PlayerDeleted WHERE PID = :pid");
                q.SetParameter("pid", PID);
                return (PlayerDeleted)q.UniqueResult();
            }
        }
    }
}
