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
            if (CheckNotDuplicateValuesObjectsGame(objectsGame) && CheckCountObjectsGame(objectsGame) && CheckMissingValuesObjectsGame(objectsGame))
            {
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
            get { return playingField[x, y]; }
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
                this.dimensionField = (int)wholePartDimensionField;
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

            if (CheckMoveUp(currentCell))
            {
                playingField[currentCell.x, currentCell.y] = 0;
                playingField[locationCell[0].x, locationCell[0].y] = value;

                locationCell[value].x++;
                locationCell[0].x--;
            }
            else if (CheckMoveDown(currentCell))
            {
                playingField[currentCell.x, currentCell.y] = 0;
                playingField[locationCell[0].x, locationCell[0].y] = value;

                locationCell[value].x--;
                locationCell[0].x++;
            }
            else if (CheckMoveLeft(currentCell))
            {
                playingField[currentCell.x, currentCell.y] = 0;
                playingField[locationCell[0].x, locationCell[0].y] = value;

                locationCell[value].y++;
                locationCell[0].y--;
            }
            else if (CheckMoveRight(currentCell))
            {
                playingField[currentCell.x, currentCell.y] = 0;
                playingField[locationCell[0].x, locationCell[0].y] = value;

                locationCell[value].y++;
                locationCell[0].y--;
            }
            else throw new ArgumentException("Ноль находится не на соседнем месте!");
        }

        private bool CheckMoveUp(Cell cell)
        {
            if (cell.y != 0)
            {
                if (playingField[cell.x, cell.y + 1] == 0)
                    return true;
                else
                    return false;
            }

            return false;
        }

        private bool CheckMoveDown(Cell cell)
        {
            if (cell.x != dimensionField - 1)
            {
                if (playingField[cell.x - 1, cell.y] == 0)
                    return true;
                else
                    return false;
            }

            return false;
        }

        private bool CheckMoveLeft(Cell cell)
        {
            if (cell.y != 0)
            {
                if (playingField[cell.x, cell.y - 1] == 0)
                    return true;
                else
                    return false;
            }

            return false;
        }

        private bool CheckMoveRight(Cell cell)
        {
            if (cell.y != dimensionField - 1)
            {
                if (playingField[cell.x, cell.y + 1] == 0)
                    return true;
                else
                    return false;
            }

            return false;
        }
     
        static void Main(string[] args)
        {
            Game g = new Game(1, 2, 3, 0);
            g.Shift(3);
        }
    }
}
