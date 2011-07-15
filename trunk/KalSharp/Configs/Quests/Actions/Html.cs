using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KalSharp.Worlds.Characters;
using Kml;

namespace KalSharp.Configs.Quests.Actions
{
    public class Html : Action
    {
        public int HtmlID;

        public Html(int HtmlID)
        {
            this.HtmlID = HtmlID;
        }

        public Html(KmlNode Node)
        {
            this.HtmlID = Node.Values[1].ValueAsInt;
        }

        public override void Execute(Character Character)
        {
            Character.ShowHtml(HtmlID);
        }
    }
}
