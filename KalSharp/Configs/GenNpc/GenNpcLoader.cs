using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KalSharp.Configs;
using Kml;

namespace KalSharp.Configs.GenNpc
{
    class GenNpcLoader
    {
        public static GenNpc Load(KmlNode Node)
        {
            GenNpc genNpc = new GenNpc();

            genNpc.Index = Node.SelectSingleNode("index").Values[1].ValueAsInt;


            return genNpc;
        }
    }
}
