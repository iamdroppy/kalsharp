using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KalSharp.Configs.ConfigPropertyTypes;
using KalSharp.Configs.InitItems.ItemCodes;

namespace KalSharp.Configs.InitItems
{
    public class InitItem : ConfigType
    {
        /// <summary>
        /// Name index of the item.
        /// </summary>
        public int Name;
        /// <summary>
        /// Unique item index.
        /// </summary>
        public int Index;
        /// <summary>
        /// Determins which model will be used for the item. Not needed.
        /// </summary>
        //public Action Action;
        /// <summary>
        /// How much the item costs to buy from an NPC.
        /// </summary>
        public int Buy;
        /// <summary>
        /// The type of item.
        /// </summary>
        public Class Class;
        /// <summary>
        /// 
        /// </summary>
        //public InitItemCocoon Cocoon;
        /// <summary>
        /// Determins the type of item.
        /// </summary>
        public Code Code;
        /// <summary>
        /// Cooldown time before the item can be used again in milliseconds.
        /// </summary>
        public int Cooltime;
        /// <summary>
        /// Country the item is available in.
        /// </summary>
        public Country Country;
        /// <summary>
        /// Item description index. Not Needed.
        /// </summary>
        //public int Desc;
        /// <summary>
        /// Effect displayed when item is used.
        /// </summary>
        public int Effect;
        /// <summary>
        /// Durability of item.
        /// </summary>
        public int Endurance;
        /// <summary>
        /// Item grade.
        /// </summary>
        public int Level;
        /// <summary>
        /// Limits the item to class/level.
        /// </summary>
        public Limit Limit;
        /// <summary>
        /// 
        /// </summary>
        public int MaxProtect;
        /// <summary>
        /// 
        /// </summary>
        public int Pay;
        /// <summary>
        /// Determins whether or not the item can be stacked.
        /// </summary>
        public int Plural;
        /// <summary>
        /// The race to transform Numbero on item use.
        /// </summary>
        public int Race;
        /// <summary>
        /// Attack range of item.
        /// </summary>
        public int Range;
        /// <summary>
        /// Sell value to NPC.
        /// </summary>
        public int Sell;
        /// <summary>
        /// Specialty values.
        /// </summary>
        public Specialties.Specialty Specialty = new Specialties.Specialty();
        /// <summary>
        /// Determines if the item can be used.
        /// </summary>
        public int Use;
        /// <summary>
        /// War relation.
        /// </summary>
        public int WarRelation;

        public static bool ContainsIndex(int Index)
        {
            foreach (InitItem initItem in Config.InitItem)
            {
                if (initItem.Index == Index)
                {
                    return true;
                }
            }
            return false;
        }
    }

    
}
