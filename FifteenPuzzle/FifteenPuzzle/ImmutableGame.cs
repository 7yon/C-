using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzle
{
    public class ImmutableGame : Game
    {
        public ImmutableGame(params int[] objectsGame) : base(objectsGame)
        {
            
        }

        public new ImmutableGame Shift(int value)
        {
            int[] objects = new int[DimensionField * DimensionField];

            Cell currentCell = GetLocation(value);
            Cell zeroCell = MoveTo(currentCell);

            if (zeroCell != null)
            {
                for (int i = 0; i < DimensionField; i++)
                {
                    for (int j = 0; j < DimensionField; j++)
                    {
                        objects[i * DimensionField + j] = PlayingField[i, j];
                    }
                }

                objects[currentCell.X * DimensionField + currentCell.Y] = 0;
                objects[zeroCell.X * DimensionField + zeroCell.Y] = value;
            }
                return new ImmutableGame(objects);           
        }
    }
}
