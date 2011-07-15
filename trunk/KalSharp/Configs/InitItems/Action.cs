using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KalSharp.Configs.InitItems
{
    public class Action
    {
        public int Primary;
        public int Secondary;

        public Action(int Primary, int Secondary)
        {
            this.Primary = Primary;
            this.Secondary = Secondary;
        }
    }
}
