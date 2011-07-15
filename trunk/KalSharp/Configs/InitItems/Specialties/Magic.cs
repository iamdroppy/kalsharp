using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KalSharp.Configs.InitItems.Specialties
{
    public class Magic
    {
        /// <summary>
        /// The minimum amount of magic damage done.
        /// </summary>
        public ushort Min;
        /// <summary>
        /// The maximum amount of magic damage done.
        /// </summary>
        public ushort Max;
        //todo: find out what value3 is
        public ushort Value3;

        /// <summary>
        /// How much damage will be done with this item.
        /// </summary>
        /// <param name="Min">The minimum amount of magic damage done.</param>
        /// <param name="Max">The maximum amount of magic damage done.</param>
        public Magic(ushort Min, ushort Max)
        {
            this.Min = Min;
            this.Max = Max;
        }

        public Magic(ushort Min, ushort Max, ushort Value3)
        {
            this.Min = Min;
            this.Max = Max;
            this.Value3 = Value3;
        }
    }
}
