using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class AbilityForMana : Ability
    {
        public override void Execute(Personage personage, int difference)
        {
            personage.AddEffects(new EffectAbilityForMana(difference));
        }
    }
}
