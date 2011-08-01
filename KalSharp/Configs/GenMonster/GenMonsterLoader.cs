using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KalSharp.Configs;
using Kml;

namespace KalSharp.Configs.GenMonster
{
    class GenMonsterLoader
    {
        public static GenMonster Load(KmlNode Node)
        {
            GenMonster genMonster = new GenMonster();

            genMonster.Index = Node.SelectSingleNode("index").Values[1].ValueAsInt;
            genMonster.Cycle = Node.SelectSingleNode("cycle").Values[1].ValueAsInt;
            genMonster.Area = Node.SelectSingleNode("area").Values[1].ValueAsInt;
            genMonster.Map = Node.SelectSingleNode("map").Values[1].ValueAsInt;
            genMonster.Max = Node.SelectSingleNode("max").Values[1].ValueAsInt;

            //rect
            int X1 = Node.SelectSingleNode("rect").Values[1].ValueAsInt;
            int Y1 = Node.SelectSingleNode("rect").Values[2].ValueAsInt;
            int X2 = Node.SelectSingleNode("rect").Values[3].ValueAsInt;
            int Y2 = Node.SelectSingleNode("rect").Values[4].ValueAsInt;
            genMonster.Rect = new GenMonsterRect(X1,Y1,X2,Y2);

            genMonster.Max = Node.SelectSingleNode("max").Values[1].ValueAsInt;

            return genMonster;
        }
    }
}
