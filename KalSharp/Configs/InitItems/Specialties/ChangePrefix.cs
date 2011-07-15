using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KalSharp.Configs.InitItems.Specialties
{
    public class ChangePrefix
    {
        /// <summary>
        /// The type of item to change the prefix of.
        /// </summary>
        public string Type;
        /// <summary>
        /// The chance to set the primary prefix.
        /// </summary>
        public int PrimaryPrefixChance;
        /// <summary>
        /// The index of the primary prefix.
        /// </summary>
        public int PrimaryPrefixIndex;
        /// <summary>
        /// The chance to set the secondary prefix.
        /// </summary>
        public int SecondaryPrefixChance;
        /// <summary>
        /// The index of the secondary prefix.
        /// </summary>
        public int SecondaryPrefixIndex;

        /// <summary>
        /// Changes the prefix of an item when used.
        /// </summary>
        /// <param name="Type">The type of item to change the prefix of.</param>
        /// <param name="PrimaryPrefixChance">The chance to set the primary prefix.</param>
        /// <param name="PrimaryPrefixIndex">The index of the primary prefix.</param>
        /// <param name="SecondaryPrefixChance">The chance to set the secondary prefix.</param>
        /// <param name="SecondaryPrefixIndex">The index of the secondary prefix.</param>
        public ChangePrefix(string Type, int PrimaryPrefixChance, int PrimaryPrefixIndex, int SecondaryPrefixChance, int SecondaryPrefixIndex)
        {
            this.Type = Type;
            this.PrimaryPrefixChance = PrimaryPrefixChance;
            this.PrimaryPrefixIndex = PrimaryPrefixIndex;
            this.SecondaryPrefixChance = SecondaryPrefixChance;
            this.SecondaryPrefixIndex = SecondaryPrefixIndex;
        }
    }
}
