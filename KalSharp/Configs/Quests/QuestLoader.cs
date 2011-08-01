using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KalSharp.Configs;
using Kml;

namespace KalSharp.Configs.Quests
{
    class QuestLoader
    {
        public static Quest Load(KmlNode Node)
        {
            Quest quest = new Quest();

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

        public static Case LoadCase(KmlNode CaseNode)
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

        public static Action LoadAction(KmlNode ActionNode)
        {
            Action action = ActionManager.CreateAction(ActionNode);

            return action;
        }
    }
}
