using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessorGeneric
{
    public class Entity
    {
        private Engine engine;

        public Processor<Engine, Entity, Logger> With<TLogger>()
        {
            return new Processor<Engine, Entity, Logger>();
        }
    }
}
