using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzle
{
    public class Cell
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Cell(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public void ChangeCoordinates(Cell cell)
        {
            X = cell.X;
            Y = cell.Y;
        }
    }
}
