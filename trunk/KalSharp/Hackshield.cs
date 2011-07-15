using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KalSharp
{
    public enum OffenseSeverity
    {
        IncorrectPacketDetails = 0,
        OutOfPlacePacket = 1,
        CooldownHacking = 2,
        SpeedHacking = 3,
        UndergroundHacking = 4,
    }

    public static class Hackshield
    {
        private static Dictionary<OffenseSeverity, int> suspicionList;

        public static void Load()
        {
            ServerConsole.WriteLine("Hackshield Initializing", MessageLevel.Hackshield);

            suspicionList = new Dictionary<OffenseSeverity, int>();
            suspicionList.Add(OffenseSeverity.IncorrectPacketDetails, 50);
            suspicionList.Add(OffenseSeverity.OutOfPlacePacket, 100);
            suspicionList.Add(OffenseSeverity.CooldownHacking, 25);
            suspicionList.Add(OffenseSeverity.SpeedHacking, 25);
            suspicionList.Add(OffenseSeverity.UndergroundHacking, 25);
        }

        public static void AddOffense(Client Client, OffenseSeverity Severity)
        {
            Client.Suspicion += suspicionList[Severity];
            WarnClient(Client, Severity);
            //check if we need to ban the client.
            if (Client.Suspicion >= 100)
            {
                //Client.Ban();
            }
        }

        private static void WarnClient(Client Client, OffenseSeverity Severity)
        {
            string message = "";
            switch (Severity)
            {
                case OffenseSeverity.CooldownHacking:
                    message += "It has been detected that your client is cooldown hacking, further warnings will result in a ban.";
                    break;
                case OffenseSeverity.SpeedHacking:
                    message += "It has been detected that your client is speed hacking, further warnings will result in a ban.";
                    break;
                case OffenseSeverity.OutOfPlacePacket:
                    message += "An out of place packet has been detected, this may be due to lag or bad programming, please restart your game and ensure you have the latest update.";
                    break;
                case OffenseSeverity.IncorrectPacketDetails:
                    message += "One or more of your packets containa invalid data, this may be due to lag or bad programming, please restart your game and ensure you have the latest update.";
                    break;
                case OffenseSeverity.UndergroundHacking:
                    message += "It has been detected that your client is underground hacking, further warnings will result in a ban.";
                    break;
            }

            Client.Send(new Packets.Chat("Hackshield",message,new object[] {}));
        }
    }
}
