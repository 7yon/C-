using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzle
{
    public class Game
    {
        private int[,] playingField;
        private Cell[] locationCell;
        private int dimensionField;

        public Game(params int[] objectsGame)
        {        
            if (CheckNotDuplicateValuesObjectsGame(objectsGame) 
                && CheckCountObjectsGame(objectsGame) 
                && CheckMissingValuesObjectsGame(objectsGame))
            {
                dimensionField = (int)Math.Sqrt(objectsGame.Length);
                playingField = new int[dimensionField, dimensionField];
                locationCell = new Cell[dimensionField * dimensionField];

                for(int i = 0; i < dimensionField; i++)
                {
                    for(int j = 0;j < dimensionField; j++)
                    {
                        int value = objectsGame[i * dimensionField + j];
                        playingField[i, j] = value;
                        locationCell[value] = new Cell(i, j);                      
                    }
                }
            }
        }

        public int this[int x, int y]
        {
            get {
                if ((x >= 0 && x < dimensionField) && (x >= 0 && x < dimensionField))
                    return playingField[x, y];
                else throw new ArgumentException("Индесы выходят за пределы массива!");
            }
        }

        public Cell GetLocation(int value)
        {
            return locationCell[value];
        }

        private bool CheckCountObjectsGame(int[] objectsGame)
        {
            double dimensionField = Math.Sqrt(objectsGame.Length);
            double wholePartDimensionField = dimensionField - (dimensionField % (int)dimensionField);

            if ((dimensionField - wholePartDimensionField) == 0)
            {
                return true;
            }
            else
                throw new ArgumentException("Из данного количества аргументов в массиве невозможно построить квадратное игровое поле!");
        }

        private bool CheckNotDuplicateValuesObjectsGame(int[] objectsGame)
        {
            for (int i = 0; i < objectsGame.Length; i++)
            {
                int value = objectsGame[i];
                for (int j = i + 1; j < objectsGame.Length; j++)
                {
                    if (value == objectsGame[j])
                        throw new ArgumentException("Повторяющиеся значения в аргументах конструктора!");
                }
            }
            return true;
        }

        private bool CheckMissingValuesObjectsGame(int[] objectsGame)
        {
            int length = objectsGame.Length;
            for (int i = 0; i < length; i++)
            {
                if ((objectsGame[i] < 0) || (objectsGame[i] >= length))
                    throw new ArgumentException("Значение < 0 или >= количества элементов!");
            }
            return true;
        }

        public void Shift(int value)
        {
            Cell currentCell = GetLocation(value);
            Cell zeroCell = MoveTo(currentCell);

            if (zeroCell != null)
            {
                playingField[currentCell.X, currentCell.Y] = 0;
                playingField[locationCell[0].X, locationCell[0].Y] = value;

                locationCell[0] = locationCell[value];
                locationCell[value] = zeroCell;
            }
            else throw new ArgumentException("Ноль находится не на соседнем месте!");
        }

        private Cell MoveTo(Cell cell)
        {
            if (cell.X != dimensionField - 1)
            {
                if (playingField[cell.X + 1, cell.Y] == 0)
                    return GetLocation(0);
            }
            if (cell.X != 0)
            {
                if (playingField[cell.X - 1, cell.Y] == 0)
                    return GetLocation(0);
            }
            if (cell.Y != 0)
            {
                if (playingField[cell.X, cell.Y - 1] == 0)
                    return GetLocation(0);
            }
            if (cell.Y != dimensionField - 1)
            {
                if (playingField[cell.X, cell.Y + 1] == 0)
                    return GetLocation(0);
            }

            return null;
        }
    }
}
