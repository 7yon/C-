﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessorGeneric
{
    public class Engine
    {
        public TEntity For<TEntity>() where TEntity : new()
        {
            return new TEntity();
        }
    }
}
