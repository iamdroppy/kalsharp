using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KalSharp.Configs.InitItems.Specialties
{
    public class Buff
    {
        /// <summary>
        /// The index of the buff to be applied.
        /// </summary>
        public int Index;
        /// <summary>
        /// How long the buff lasts for in seconds.
        /// </summary>
        public int Duration;
        /// <summary>
        /// How strong the buff will be.
        /// </summary>
        public int Grade;

        /// <summary>
        /// Applies a buff on item use.
        /// </summary>
        /// <param name="Index">The index of the buff to be applied.</param>
        /// <param name="Duration">How long the buff lasts for in seconds.</param>
        /// <param name="Grade">How strong the buff will be.</param>
        public Buff(int Index, int Duration, int Grade)
        {
            this.Index = Index;
            this.Duration = Duration;
            this.Grade = Grade;
        }

        public Buff(int Index, int Duration)
        {
            this.Index = Index;
            this.Duration = Duration;
            this.Grade = 0;
        }
    }
}
