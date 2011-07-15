using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KalSharp.Configs.InitItems.Specialties
{
    public enum GStateValue
    {
        Dead = 1,
        Resting = 2,
        Unknown_3 = 3,
        Stun = 4,
        Fishing = 5,
        Unknown_6 = 6,
        Duel = 7,
        Assassin = 8,
        Unknown_9 = 9,
        Unknown_10 = 10,
        Unknown_11 = 11,
        Unknown_12 = 12,
        Unknown_13 = 13,
        Gliding = 14,
        Unknown_15 = 15,
        Unknown_16 = 16,
        Unknown_17 = 17,
        Unknown_18 = 18,
        Unknown_19 = 19,
        ShadowStone = 20,
        HolyStone = 21,
        FireStone = 22,
        IceStone = 23,
        LightningStone = 24,
        PoisonStone = 25,
        ParalysisStone = 26,
        StrengthStone = 27,
        SkillStone = 28,
        MysteryStone = 29,
        DemonBloodStone = 30,
        Unknown_31 = 31,
        Unknown_32 = 32,
    }

    public class GState
    {
        public GStateValue Value;

        public GState(GStateValue Value)
        {
            this.Value = Value;
        }
    }
}
