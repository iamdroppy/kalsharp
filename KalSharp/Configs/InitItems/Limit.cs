using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KalSharp.Configs.InitItems
{
    public class Limit
    {
        public int Class;
        public int Level;

        public Limit(int Class, int Level)
        {
            this.Class = Class;
            this.Level = Level; 
        }
    }
}
