using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    public class Program
    {
        static void main()
        {
            Table table = new Table();

            LoggingSystem system = new LoggingSystem(table);

            table.InsertRow(0);
            table.InsertColumn(0);
            table.Put(0, 0, 1);

            table.AddObserver(system);
            table.NotifyObservers();
        }
    }
}
