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
            ImmutableGame game = new ImmutableGame(1, 2, 3, 0, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);

            Decorator newGame = new Decorator(game);

            int v = newGame[1, 2];

            //Assert.AreEqual(0, game[0, 3]);
            //Assert.AreEqual(3, newGame[0, 3]);
            //Assert.AreEqual(3, game[0, 2]);
            //Assert.AreEqual(0, newGame[0, 2]);

            //ImmutableGame game = new ImmutableGame(1, 2, 3, 0, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);

            //Decorator decorator = new Decorator(game);
            //Decorator newGame = decorator.Shift(3);
            //Cell cell = newGame.GetLocation(3);
        }
    }
}
