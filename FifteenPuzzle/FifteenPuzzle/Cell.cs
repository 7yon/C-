using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzle
{
    public class Cell
    {
        public int x { get; set; }
        public int y { get; set; }

        public Cell(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        //public void MoveUp()
        //{
        //    x += 1;
        //}

        //public void MoveDown()
        //{
        //    x -= 1;
        //}

        //public void MoveLeft()
        //{
        //    y -= 1;
        //}

        //public void MoveRight()
        //{
        //    y += 1;
        //}
    }
}
