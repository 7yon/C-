using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    public class LoggingSystem : IObserver
    {
        private List<List<int>> table = new List<List<int>>();

        public LoggingSystem(List<List<int>> table)
        {
            this.table = table;
        }

        public void Update(List<List<int>> table)
        {
            this.table = table;
        }
    }
}
