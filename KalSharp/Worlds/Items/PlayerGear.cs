using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace KalSharp.Worlds.Items
{
    public class PlayerGear : Gear
    {
        public ushort Weapon = 0;
        public ushort Boots = 0;
        public ushort Gauntlet = 0;
        public ushort Helmet = 0;
        public ushort LowerArmor = 0;
        public ushort UpperArmor = 0;
        public ushort Shield = 0;
        public ushort Mask = 0;
        public ushort Flag = 0;
        public ushort Necklase = 0;
        public ushort Ring = 0;
        public ushort Trinket = 0;

       // writer.Write(gear.Weapon);
       //     writer.Write(gear.Shield);
       //     writer.Write(gear.Helmet);
       //     writer.Write(gear.UpperArmor);
        //    writer.Write(gear.LowerArmor);
        //    writer.Write(gear.Gauntlet);
        //    writer.Write(gear.Boots); 

        public Player Player;

        public PlayerGear(Player Player)
        {
            this.Player = Player;
        }

        public override Dictionary<int, ushort> Slots
        {
            get 
            {
                Dictionary<int, ushort> slots = new Dictionary<int, ushort>();

                //fill with blanks
                for (int i = 1; i < 8; i++)
                {
                    slots[i] = 0;
                }

                foreach (Item Item in EquippedItems)
                {
                    switch ((int)Item.InitItem.Code.Tertiary)
                    {
                        case 1:
                            //melee
                            slots[1] =(ushort)Item.Index;
                            break;

                        case 2:
                            //ranged
                            slots[1] =(ushort)Item.Index;
                            break;
                        case 3:
                            //upper armor
                            slots[4] =(ushort)Item.Index;
                            break;
                        case 4:
                            //helmet
                            slots[3] =(ushort)Item.Index;
                            break;
                        case 5:
                            //gauntlet
                            slots[6] =(ushort)Item.Index;
                            break;
                        case 6:
                            //boots
                            slots[7] =(ushort)Item.Index;
                            break;
                        case 7:
                            //lower armor
                            slots[5] =(ushort)Item.Index;
                            break;
                        case 8:
                            //shield
                            slots[2] =(ushort)Item.Index;
                            break;
                    }
                }
                return slots;
            }
        }

        public override List<Item> EquippedItems
        {
            get
            {
                using (ISession session = Database.KalDB.OpenSession())
                {
                    //todo animal system
                    IQuery q = session.CreateQuery("FROM Item WHERE (Info = 1 OR Info = 9) AND PID = :pid");
                    q.SetParameter("pid", Player.PID);
                    return (List<Item>)q.List<Item>();
                }
            }
        }
    }
}
