using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzle
{
    class ImmutableGame
    {
        private int[,] playingField;
        private ImmutableCell[] locationCell;
        private int dimensionField;

        public ImmutableGame(params int[] objectsGame)
        {
            if (CheckObjectsGame(objectsGame))
            {
                dimensionField = (int)Math.Truncate(Math.Sqrt(objectsGame.Length));
                playingField = new int[dimensionField, dimensionField];
                locationCell = new ImmutableCell[dimensionField * dimensionField];

                for (int i = 0; i < dimensionField; i++)
                {
                    for (int j = 0; j < dimensionField; j++)
                    {
                        int value = objectsGame[i * dimensionField + j];
                        playingField[i, j] = value;
                        locationCell[value] = new ImmutableCell(i, j);
                    }
                }
            }
        }
        
        public ImmutableGame(int[,] playingField, ImmutableCell[] locationCell)
        {
            playingField.CopyTo(this.playingField, 0);
            this.locationCell = new ImmutableCell[locationCell.Length];

            for(int i=0; i < locationCell.Length;i++)
            {
                this.locationCell[i] = new ImmutableCell(locationCell[i]);
            }
        }

        public int this[int x, int y]
        {
            get
            {
                if ((x >= 0 && x < dimensionField) && (x >= 0 && x < dimensionField))
                    return playingField[x, y];
                else throw new ArgumentOutOfRangeException();
            }
        }

        public ImmutableCell GetLocation(int value)
        {
            if ((value >= 0) && (value < dimensionField * dimensionField))
                return locationCell[value];
            else throw new ArgumentOutOfRangeException();
        }

        private bool CheckObjectsGame(int[] objectsGame)
        {
            int closestRoot = (int)Math.Sqrt(objectsGame.Length);

            if (objectsGame.Length != Math.Pow(closestRoot, 2))
                throw new ArgumentException("Из данного количества аргументов в массиве невозможно построить квадратное игровое поле!");

            for (int i = 0; i < objectsGame.Length; i++)
            {
                int value = objectsGame[i];
                for (int j = i + 1; j < objectsGame.Length; j++)
                {
                    if (value == objectsGame[j])
                        throw new ArgumentException("Повторяющиеся значения в аргументах конструктора!");
                }
            }

            int length = objectsGame.Length;
            for (int i = 0; i < length; i++)
            {
                if ((objectsGame[i] < 0) || (objectsGame[i] >= length))
                    throw new ArgumentException("Значение < 0 или >= количества элементов!");
            }

            return true;
        }

        public ImmutableGame Shift(int value)
        {
            ImmutableCell currentCell = GetLocation(value);
            ImmutableCell zeroCell = MoveTo(currentCell);

            if (zeroCell != null)
            {
                playingField[currentCell.X, currentCell.Y] = 0;
                playingField[locationCell[0].X, locationCell[0].Y] = value;

                locationCell[0] = locationCell[value];
                locationCell[value] = zeroCell;

                return new ImmutableGame(playingField, locationCell);
            }
            else throw new ArgumentException("Ноль находится не на соседнем месте!");
        }

        private ImmutableCell MoveTo(ImmutableCell cell)
        {
            ImmutableCell zero = GetLocation(0);

            if (((Math.Abs(zero.X - cell.X) == 1) && (zero.Y == cell.Y)) || ((Math.Abs(zero.Y - cell.Y) == 1) && (zero.X == cell.X)))
                return zero;
            else return null;
        }
    }
}
