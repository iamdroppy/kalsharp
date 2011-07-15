using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KalSharp.Configs.ConfigPropertyTypes
{
    public class Country
    {
        public bool Korea;
        public bool China;
        public bool International;

        public Country(bool Korea, bool International, bool China)
        {
            this.Korea = Korea;
            this.China = China;
            this.International = International;
        }
    }
}
