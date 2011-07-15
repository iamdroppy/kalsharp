using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KalSharp.Worlds.Skills
{
    public class SkillHandler
    {
        public Dictionary<byte, ISkill> Handlers = new Dictionary<byte, ISkill>();

        public void Add(byte skillId, ISkill skill)
        {
            Handlers[skillId] = skill;
        }

        public void Execute(byte skillId, byte skillLvl)
        {

        }

        public void Request(byte skillId, uint playerId)
        {
            if (!Handlers.ContainsKey(skillId))
            {
                ServerConsole.WriteLine("Unknown Skill Id #{0}",MessageLevel.Error, skillId);
            }
        }
    }
}
