using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KalSharp.Configs;
using Kml;
using KalSharp.Configs.ConfigPropertyTypes;
using KalSharp.Configs.Quests;

namespace KalSharp.Configs.Loaders
{
    class InitMap : ConfigLoader
    {
        public override ConfigType Load(KmlNode Node)
        {
            Configs.InitMap map = new Configs.InitMap();

            map.Index = Node.SelectSingleNode("index").Values[1].ValueAsInt;
            map.Kind = Node.SelectSingleNode("kind").Values[1].ValueAsInt;
            map.Location.X = Node.SelectSingleNode("xy").Values[1].ValueAsInt;
            map.Location.Y = Node.SelectSingleNode("xy").Values[2].ValueAsInt;
            map.FileName = Node.SelectSingleNode("filename").Values[1].Value;

            return map;
        }

    }
}
