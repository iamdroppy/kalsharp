using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KalSharp.Worlds.Characters;
using Kml;

namespace KalSharp.Configs.Quests.Actions
{
    class Guide : Action
    {
        public int GuideID;

        public Guide(int GuideID)
        {
            this.GuideID = GuideID;
        }

        public Guide(KmlNode Node)
        {
            this.GuideID = Node.Values[1].ValueAsInt;
        }

        public override void Execute(Character Character)
        {
            // Character.ShowHtml(GuideID);
        }
    }
}
