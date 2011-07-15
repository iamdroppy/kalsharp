using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KalSharp.Configs;
using Kml;
using KalSharp.Configs.ConfigPropertyTypes;
using KalSharp.Configs.Quests;

namespace KalSharp.Configs.Loaders
{
    class Quest : ConfigLoader
    {
        public override ConfigType Load(KmlNode Node)
        {
            Quests.Quest quest = new Quests.Quest();

            quest.Index = Node.SelectSingleNode("index").Values[1].ValueAsInt;
            quest.Stage = Node.SelectSingleNode("index").Values[2].ValueAsInt;

            if(Node.ChildNodes.ContainsKey("linked"))
            {
                int linkedValue = Node.SelectSingleNode("linked").Values[1].ValueAsInt;

                if (linkedValue == 1)
                {
                    quest.Linked = true;
                }
                else
                {
                    quest.Linked = false;
                }
            }

            quest.Cases = new List<Case>();
            //load cases
            foreach (KmlNode caseNode in Node.SelectNodes("case"))
            {
                quest.Cases.Add(LoadCase(caseNode));
            }


            return quest;
        }

        public Case LoadCase(KmlNode CaseNode)
        {
            Case newCase = new Case();
            newCase.Actions = new List<Quests.Action>();
            newCase.Conditions = new List<Condition>();
            //load conditions
            //KmlNode conditions = CaseNode.SelectSingleNode("if");
            //foreach (KmlNode conditionNode in conditions.ChildNodes)
            //{
            //    newCase.Conditions.Add(LoadCondition(conditionNode));
            //}

            //load actions
            KmlNode actions = CaseNode.SelectSingleNode("then");
            foreach (KmlNode actionNode in actions.ChildNodes)
            {
                newCase.Actions.Add(LoadAction(actionNode));
            }

            return newCase;
        }

        //public Condition LoadCondition(KmlNode ConditionNode)
       // {
       //     Condition condition = new Condition();
//
       //     return condition;
       // }

        public Quests.Action LoadAction(KmlNode ActionNode)
        {
            Quests.Action action = ActionManager.CreateAction(ActionNode);

            return action;
        }
    }
}
