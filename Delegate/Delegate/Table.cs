using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    public class Table
    {
        public List<List<int>> TableValues { get; private set; }
        private List<IObserver> observers = new List<IObserver>();

        public Table()
        {
            TableValues = new List<List<int>>();           
        }
        public void Put(int row, int column, int value)
        {
            TableValues[row][column] = value;
            NotifyObservers();
        }

        public void InsertRow(int rowIndex)
        {
            TableValues.Insert(rowIndex, new List<int>());
            NotifyObservers();
        }

        public void InsertColumn(int columnIndex)
        {
            for(int i = 0; i < TableValues.Count; i++)
            {
                TableValues[i].Insert(columnIndex, default(int));
            }
            NotifyObservers();
        }

        public int Get(int row, int column)
        {
            return TableValues[row][column];
        }

        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        private void NotifyObservers()
        {
            foreach (IObserver o in observers)
            {
                o.Update(TableValues);
            }
        }
    }
}
