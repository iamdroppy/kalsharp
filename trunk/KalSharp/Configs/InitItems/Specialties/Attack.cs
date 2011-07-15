using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KalSharp.Configs.InitItems.Specialties
{
    public class Attack
    {
        /// <summary>
        /// Minimum Attack Damage.
        /// </summary>
        public ushort Min;
        /// <summary>
        /// Maximum Attack Damage.
        /// </summary>
        public ushort Max;

        /// <summary>
        /// Value 3???
        /// </summary>
        public ushort Value3;

        /// <summary>
        /// How much damage the item will do.
        /// </summary>
        /// <param name="Min">Minimum Attack Damage.</param>
        /// <param name="Max">Maximum Attack Damage.</param>
        public Attack(ushort Min, ushort Max)
        {
            this.Min = Min;
            this.Max = Max;
        }

        /// <summary>
        /// How much damage the item will do.
        /// </summary>
        /// <param name="Min">Minimum Attack Damage.</param>
        /// <param name="Max">Maximum Attack Damage.</param>
        /// <param name="Value3">???</param>
        public Attack(ushort Min, ushort Max, ushort Value3)
        {
            this.Min = Min;
            this.Max = Max;
            this.Value3 = Value3;
        }
    }
}
