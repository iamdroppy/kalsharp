using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace KalSharp.Worlds.Skills
{
    public interface ISkill
    {
        void OnRequest(PlayerSkill skill, Player caster, Player target);

        void OnExecute(PlayerSkill skill, Player caster, byte mode, byte level, Player target);

        void OnPassiveApply(PlayerSkill skill, Player caster, byte level);

        void OnPassiveRemove(PlayerSkill skill, Player caster, byte level);
    }
}
