using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzle
{
    public class Game
    {
        public int[,] PlayingField { get; private set; }
        public Cell[] LocationCell { get; private set; }
        public int DimensionField { get; private set; }

        public Game(params int[] objectsGame)
        {        
            if (CheckObjectsGame(objectsGame))
            {
                DimensionField = (int)Math.Truncate(Math.Sqrt(objectsGame.Length));
                PlayingField = new int[DimensionField, DimensionField];
                LocationCell = new Cell[DimensionField * DimensionField];

                for(int i = 0; i < DimensionField; i++)
                {
                    for(int j = 0;j < DimensionField; j++)
                    {
                        int value = objectsGame[i * DimensionField + j];
                        PlayingField[i, j] = value;
                        LocationCell[value] = new Cell(i, j);                      
                    }
                }
            }
        }
        
        public Game(Game game)
        {
            game.PlayingField.CopyTo(this.PlayingField, 0);
            this.LocationCell = new Cell[game.LocationCell.Length];

            for (int i = 0; i < game.LocationCell.Length; i++)
            {
                this.LocationCell[i] = new Cell(game.LocationCell[i]);
            }
        }

        public int this[int x, int y]
        {
            get {
                if ((x >= 0 && x < DimensionField) && (x >= 0 && x < DimensionField))
                    return PlayingField[x, y];
                else throw new ArgumentOutOfRangeException();
            }
        }

        public Cell GetLocation(int value)
        {
            if ((value >= 0) && (value < DimensionField * DimensionField))
                return LocationCell[value];
            else throw new ArgumentOutOfRangeException();
        }

        protected bool CheckObjectsGame(int[] objectsGame)
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

        public Game Shift(int value)
        {
            Cell currentCell = GetLocation(value);
            Cell zeroCell = MoveTo(currentCell);

            if (zeroCell != null)
            {
                PlayingField[currentCell.X, currentCell.Y] = 0;
                PlayingField[LocationCell[0].X, LocationCell[0].Y] = value;

                LocationCell[0] = LocationCell[value];
                LocationCell[value] = zeroCell;

                return this;
            }
            else throw new ArgumentException("Ноль находится не на соседнем месте!");
        }

        private Cell MoveTo(Cell cell)
        {
            Cell zero = GetLocation(0);

            if (((Math.Abs(zero.X - cell.X) == 1) &&(zero.Y == cell.Y)) || ((Math.Abs(zero.Y - cell.Y) == 1)&& (zero.X==cell.X)))
                return zero;
            else return null;
        }
    }
}
