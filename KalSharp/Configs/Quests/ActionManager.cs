using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KalSharp.Configs.Quests.Actions;
using Kml;

namespace KalSharp.Configs.Quests
{
    public static class ActionManager
    {

        public static Action CreateAction(KmlNode Node)
        {
            string type = Node.Values[0].Value;
            switch (type)
            {
                case "html":
                    return new Html(Node);
                default:
                    throw new Exception("No action defined for " + type);
            }
        }
    }
}
