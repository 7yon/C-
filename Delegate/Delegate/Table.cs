using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    public class Table : IObservable
    {
        private List<List<int>> table = new List<List<int>>();
        private List<IObserver> observers = new List<IObserver>();

        // Если необходимо, то после каждого изменения можно вызвать NotifyObservers()

        public void Put(int row, int column, int value)
        {
            table[row][column] = value;
        }

        public void InsertRow(int rowIndex)
        {
            table.Insert(rowIndex, new List<int>());

        }

        public void InsertColumn(int columnIndex)
        {
            for(int i = 0; i < table.Count; i++)
            {
                table[i].Insert(columnIndex, default(int));
            }
        }

        public int Get(int row, int column)
        {
            return table[row][column];
        }

        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (IObserver o in observers)
            {
                o.Update(this);
            }
        }
    }
}
