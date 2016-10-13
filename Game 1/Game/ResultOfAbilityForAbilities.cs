using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class ResultOfAbilityForAbilities : ResultOfAbility
    {
        //способностей, которой хотим поделиться
        Ability newAbilities;

        public ResultOfAbilityForAbilities(DateTime timeOfEnd) : base(timeOfEnd)
        {
        }

        public void addAbilities(Ability ability)
        {
            newAbilities = ability;
        }
    }
}
