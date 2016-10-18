using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessorGeneric
{
    public class Entity
    {
        Engine engine;

        public Processor<Engine, Entity, Logger> With<TLogger>()
        {
            throw new NotImplementedException();
        }
    }
}
