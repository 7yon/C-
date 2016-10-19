using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessorGeneric
{
    public class EngineWrapper <TEngine>
    {
        public EntityWrapper<TEngine, TEntity> For<TEntity>() where TEntity : new()
        {
            return new EntityWrapper<TEngine, TEntity>();
        }
    }
}
