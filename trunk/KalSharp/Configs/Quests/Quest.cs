using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KalSharp.Configs;
using KalSharp.Configs.Quests;
using KalSharp.Worlds.Characters;

namespace KalSharp.Configs.Quests
{
    public class Quest : ConfigType
    {
        public int Index;
        public int Stage;

        public List<Case> Cases;

        public bool Linked;

        public void ExecuteQuest(Character Character)
        {
            foreach (Case ccase in Cases)
            {
                ExecuteCase(ccase, Character);
            }
        }

        private void ExecuteCase(Case Case, Character Character)
        {
            //check each condition
            foreach (Condition condition in Case.Conditions)
            {
                if (!condition.Check(Character))
                {
                    return;
                }
            }

            //execute each action
            foreach (Quests.Action action in Case.Actions)
            {
                action.Execute(Character);
            }
        }
    }
}
