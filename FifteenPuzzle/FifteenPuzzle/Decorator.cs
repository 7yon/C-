using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzle
{
    public class Decorator : Game
    {
        private ImmutableGame immutableGame;
        private int[] allChanges;

        public Decorator(ImmutableGame immutableGame)
        {
            this.immutableGame = immutableGame;
            this.allChanges = new int[0];
        }
        public Decorator(ImmutableGame immutableGame, int[] changes)
        {
            this.immutableGame = immutableGame;
            allChanges = new int[changes.Length];
            changes.CopyTo(allChanges, 0);
        }

        private ImmutableGame getCurrentGame()
        {
            ImmutableGame game = immutableGame;

            for (int i = 0; i < allChanges.Length; i++)
            {
                game = game.Shift(allChanges[i]);
            }

            return game;
        }

        public new Decorator Shift(int value)
        {
            Cell currentCell = immutableGame.GetLocation(value);
            Cell zeroCell = immutableGame.MoveTo(currentCell);

            if (zeroCell != null)
            {
                int[] newChanges = new int[allChanges.Length + 1];

                if (allChanges.Length != 0)
                {
                    allChanges.CopyTo(newChanges, 0);
                    allChanges[DimensionField] = value;
                }

                else newChanges[0] = value;

                return new Decorator(immutableGame, newChanges);
            }
            else throw new ArgumentException("Ноль находится не на соседнем месте!");
        }

        public new int this[int x, int y]
        {
            get
            {
                if ((x >= 0 && x < immutableGame.DimensionField) && (y >= 0 && y < immutableGame.DimensionField))
                {
                    return getCurrentGame()[x, y];
                }             
                else throw new ArgumentOutOfRangeException();
            }
        }

        public new Cell GetLocation(int value)
        {
            return getCurrentGame().GetLocation(value);
            throw new ArgumentOutOfRangeException();
        }
    }
}
