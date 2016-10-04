using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzle
{
    class ImmutableGame : Game
    {
        public ImmutableGame(params int[] objectsGame) : base(objectsGame)
        {
            
        }
        
        public ImmutableGame(Game game) : base(game)
        {
            
        }

        public new ImmutableGame Shift(int value)
        {
            Game newGame = base.Shift(value);

            return new ImmutableGame(newGame);           
        }
    }
}
