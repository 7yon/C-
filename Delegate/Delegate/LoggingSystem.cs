using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    public class LoggingSystem : IObserver
    {
        private IReadOnlyList<IReadOnlyList<int>> table;

        public LoggingSystem(IReadOnlyList<IReadOnlyList<int>> table)
        {
            this.table = table;
        }

        public void Update(IReadOnlyList<IReadOnlyList<int>> table)
        {
            this.table = table;
        }
    }
}
