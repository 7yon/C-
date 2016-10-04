using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(1, 2, 3, 0, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
            game.Shift(3);
        }
    }
}
