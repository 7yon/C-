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
            Triangle triangle = new Triangle(5, 5, 5);

            Console.WriteLine(triangle.AreaCalculation());
        }
    }
}
