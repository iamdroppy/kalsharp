using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kml;

namespace KalSharp.Configs.Loaders
{
    public abstract class ConfigLoader
    {
        public abstract ConfigType Load(KmlNode Node);
    }
}
