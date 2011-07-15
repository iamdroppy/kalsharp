using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KalSharp.Configs.InitItems.Specialties
{
    public enum TeleportType
    {
        Personal = 0,
        Party = 1,
    }

    public enum TeleportLocation
    {
        Narootuh = 0,
        Jook_Suh_Cargo_Station = 1,
        Geum_Oh_Mine = 2,
        The_Pub_of_the_Giant_Bird = 3,
        Temporary_Fort_of_Geum_Ohee_Castle = 4,
        City_of_Priest = 5,
    }

    public class Teleport
    {
        /// <summary>
        /// The type of teleport.
        /// </summary>
        public TeleportType Type;
        /// <summary>
        /// The location that is traveled to when used.
        /// </summary>
        public TeleportLocation Location;

        /// <summary>
        /// Teleports the user(s) when the item is used.
        /// </summary>
        /// <param name="Type">The type of teleport.</param>
        /// <param name="Location">The location that is traveled to when used.</param>
        public Teleport(TeleportType Type, TeleportLocation Location)
        {
            this.Type = Type;
            this.Location = Location;
        }

    }
}
