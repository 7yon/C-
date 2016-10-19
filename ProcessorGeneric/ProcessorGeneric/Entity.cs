using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessorGeneric
{
    public class Entity <TEngine, TEntity>
    {
        public Processor<TEngine, TEntity, TLogger> With<TLogger>()
        {
            return new Processor<TEngine, TEntity, TLogger>();
        }
    }
}
