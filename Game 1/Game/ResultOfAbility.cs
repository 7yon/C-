using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class ResultOfAbility
    {
        protected DateTime timeOfEnd;

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
