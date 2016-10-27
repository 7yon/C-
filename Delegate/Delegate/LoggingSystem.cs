using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    public class LoggingSystem : IObserver
    {
        private Table table = new Table();

        public LoggingSystem(Table table)
        {
            this.table = table;
        }

        public void Update(Table table)
        {
            this.table = table;
        }
    }
}
