using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class AbilityForMana:Ability //разновидность способности
    {
        public override ResultOfAbility CalculateResult(int difference)
        {
            //у данного вида способности другие последствия
            //конкретно меняющие кол-во маны
            //resultOfAbility.differenceOfMana = difference;
            return null;
        }
    }
}
