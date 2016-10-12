using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class ResultOfAbility //какие последствия приносит способность
    {
        /*пример последствий замедляющей и отнимающей ману способности:
         differenceOfHealth=0;
        differenceOfHitPoints=0;
        differenceOfSpeed=-20;
        differenceOfMana-40;
        differenceOfManaRegeneration;*/


        private int differenceOfHealth;
        private int differenceOfHitPoints;
        private int differenceOfSpeed;
        private int differenceOfMana;
        private int differenceOfManaRegeneration;

        private DateTime timeOfEnd;

        public ResultOfAbility(DateTime timeOfEnd)
        {
        }

        public bool IsActive()
        {
            //если время вышло, то последствия от этой способности не учитываются
            return true;
        }
    }
}
