using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KalSharp.Configs;
using Kml;
using KalSharp.Configs.ConfigPropertyTypes;

namespace KalSharp.Configs.Loaders
{
    class GenNpc : ConfigLoader
    {
        public override ConfigType Load(KmlNode Node)
        {
            Configs.GenNpc genNpc = new Configs.GenNpc();

            genNpc.Index = Node.SelectSingleNode("index").Values[1].ValueAsInt;


            return genNpc;
        }
    }
}
