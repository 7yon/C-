using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Ability
    {
        protected int cost;
        protected string description;
        protected int id;
        protected int durationOfRecharge;
        protected int durationOfAction;

        protected DateTime timeOfEndOfReload;

        public bool IsAvailable() 
        {
            //доступность способности
            //если время конца перезарядки больше чем текущее, то способность дотупна
            return true;
        }

        public virtual ResultOfAbility CalculateResult(int difference)
        {
            return null;
        }

        public virtual ResultOfAbility CalculateResult(Ability ability)
        {
            //resultOfAbility.differenceOfSpeed = difference;
            return null;
        }

    }
}
