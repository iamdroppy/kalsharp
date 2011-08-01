using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KalSharp.Configs;
using Kml;

namespace KalSharp.Configs.Maps
{
    class MapLoader
    {
        public static Map Load(KmlNode Node)
        {
            Map map = new Map();

            map.Index = Node.SelectSingleNode("index").Values[1].ValueAsInt;
            map.Kind = Node.SelectSingleNode("kind").Values[1].ValueAsInt;
            map.Location.X = Node.SelectSingleNode("xy").Values[1].ValueAsInt;
            map.Location.Y = Node.SelectSingleNode("xy").Values[2].ValueAsInt;
            map.FileName = Node.SelectSingleNode("filename").Values[1].Value;

            return map;
        }

    }
}
