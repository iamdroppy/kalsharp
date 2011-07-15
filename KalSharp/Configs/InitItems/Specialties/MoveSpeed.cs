using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KalSharp.Configs.InitItems.Specialties
{
    public class MoveSpeed
    {
        /// <summary>
        /// Change in walking speed.
        /// </summary>
        public int Walk;
        /// <summary>
        /// Change in running speed.
        /// </summary>
        public int Run;

        /// <summary>
        /// Change in movement speed when item is equipped.
        /// </summary>
        /// <param name="Walk">Change in walk speed.</param>
        /// <param name="Run">Change in run speed.</param>
        public MoveSpeed(int Walk, int Run)
        {
            this.Walk = Walk;
            this.Run = Run;
        }
    }
}
