using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinderSides;


namespace AreaTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle triangle = new Triangle(8.9, 3.9, "385d");

            Console.WriteLine(triangle.AreaCalculation());
        }
    }
}
