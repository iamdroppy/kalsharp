using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KalSharp.Configs.ConfigPropertyTypes
{
    public class GenMonsterRect
    {
        public int X1, Y1, X2, Y2;

        public GenMonsterRect(int X1, int Y1, int X2, int Y2)
        {
            this.X1 = X1;
            this.Y1 = Y1;
            this.X2 = X2;
            this.Y2 = Y2;
        }
    }
}
