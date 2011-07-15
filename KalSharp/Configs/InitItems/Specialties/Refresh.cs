using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KalSharp.Configs.InitItems.Specialties
{

    public class Refresh
    {
        /// <summary>
        /// The type of refresh, hp or mp.
        /// </summary>
        public string Type;
        /// <summary>
        /// The amount by which the type change.
        /// </summary>
        public int Amount;

        /// <summary>
        /// Change in either health or mana when the item is used.
        /// </summary>
        /// <param name="Type">The type of refresh, health or magick.</param>
        /// <param name="Amount">The amount by which the type change.</param>
        public Refresh(string Type, int Amount)
        {
            this.Type = Type;
            this.Amount = Amount;
        }
    }
}
