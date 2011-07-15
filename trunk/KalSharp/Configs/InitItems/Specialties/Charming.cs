using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KalSharp.Configs.InitItems.Specialties
{
    public class Charming
    {
        /// <summary>
        /// Type of charming to be done.
        /// </summary>
        public string Type;

        /// <summary>
        /// Charms the selected item on use.
        /// </summary>
        /// <param name="Type"></param>
        public Charming(string Type)
        {
            this.Type = Type;
        }
    }
}
