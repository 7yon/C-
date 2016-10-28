using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    public class Program
    {
        static void Main(string[] args)
        {
            Table table = new Table();

            table.InsertRow(0);
            table.InsertColumn(0);

            LoggingSystem system = new LoggingSystem(new ReadOnlyCollection<List<int>>(table.TableValues));

            table.AddObserver(system);
            table.Put(0, 0, 9);
        }
    }
}
