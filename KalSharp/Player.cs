using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KalSharp.Worlds.Items;
using KalSharp.Worlds.Skills;
using System.Data;
using KalSharp.Worlds.Stats;
using NHibernate;

namespace KalSharp
{
    public class Player
    {
        //database values
        public virtual int UID { get; set; }
        public virtual int PID { get; set; }
        public virtual byte Admin { get; set; }
        public virtual string Name { get; set; }
        public virtual byte Class { get; set; }
        public virtual byte Specialty { get; set; }
        public virtual byte Level { get; set; }
        public virtual Int16 Contribute { get; set; }
        public virtual Int64 Experience { get; set; }
        public virtual int GID { get; set; }
        public virtual byte GRole { get; set; }
        public virtual byte Strength { get; set; }
        public virtual byte Health { get; set; }
        public virtual byte Intelligence { get; set; }
        public virtual byte Wisdom { get; set; }
        public virtual byte Dexterity { get; set; }
        public virtual Int16 CurrentHP { get; set; }
        public virtual Int16 CurrentMP { get; set; }
        public virtual Int16 StatPoints { get; set; }
        public virtual Int16 SkillPoints { get; set; }
        public virtual byte Killed { get; set; }
        public virtual byte Map { get; set; }
        public virtual int X { get; set; }
        public virtual int Y { get; set; }
        public virtual int Z { get; set; }
        public virtual byte Face { get; set; }
        public virtual byte Hair { get; set; }
        public virtual byte RevivalId { get; set; }
        public virtual int Rage { get; set; }

        private List<PlayerSkill> skills = new List<PlayerSkill>();
        private PlayerGear gear;

        public virtual PlayerGear Gear
        {
            get
            {
                if (gear == null)
                {
                    gear = new PlayerGear(this);
                }
                return gear;
            }
            set
            {
                gear = value;
            }
        }

        public virtual List<PlayerSkill> Skills
        {
            get
            {
                return skills;
            }
            set
            {
                skills = value;
            }
        }

        public static Player GetPlayer(int PID)
        {
            using (ISession session = Database.KalDB.OpenSession())
            {
                IQuery q = session.CreateQuery("FROM Player WHERE PID = :pid");
                q.SetParameter("pid", PID);
                return (Player)q.UniqueResult();
            }
        }
        public static Player GetPlayer(string Name)
        {
            using (ISession session = Database.KalDB.OpenSession())
            {
                IQuery q = session.CreateQuery("FROM Player WHERE Name = :name");
                q.SetParameter("name", Name);
                return (Player)q.UniqueResult();
            }
        }
    }
}
