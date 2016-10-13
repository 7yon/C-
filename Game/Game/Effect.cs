using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Effect
    {
        public int IDAbility { get; private set; }
        public int value { get; protected set; }

        public Effect(int value, int IDAbility)
        {
            this.value = value;
            this.IDAbility = IDAbility;
        }
    }
}
