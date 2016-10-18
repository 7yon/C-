using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessorGeneric
{
    public static class ProcessorBuilder
    {
        public static TEngine CreateEngine<TEngine>() where TEngine : new()
        {
            return new TEngine();
        }
    }
}
