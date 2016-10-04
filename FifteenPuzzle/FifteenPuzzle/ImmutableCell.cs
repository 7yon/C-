using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzle
{
    public class ImmutableCell
    {
        public readonly int X;
        public readonly int Y;

        public ImmutableCell(int x, int y)
        {
            X = x;
            Y = y;
        }
        public ImmutableCell(ImmutableCell cell)
        {
            X = cell.X;
            Y = cell.Y;
        }
    }
}
