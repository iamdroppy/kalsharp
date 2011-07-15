using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KalSharp.Configs.InitItems
{
    public class Class
    {
        public string Primary;
        public string Secondary;

        public Class(string Primary, string Secondary)
        {
            this.Primary = Primary;
            this.Secondary = Secondary;
        }
    }
}
