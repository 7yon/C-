using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinderSides;

namespace AreaTriangle
{
    public class Triangle
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }
        private double area = 0;

        //Угол вводится с параметром d - "73d", сторона - 12 или 12,0
        public Triangle(double sideA, double sideB, double sideC)
        {
            var sidesTriangle = FinderSidesTriangle.CheckSides(sideA, sideB, sideC);

            SettingSides(sidesTriangle);                                  
        }

        public Triangle(double sideA, double sideB, string corner)
        {
            var sidesTriangle = FinderSidesTriangle.FindSides(sideA, sideB, corner);

            SettingSides(sidesTriangle);
        }

        public Triangle(string cornerA, string cornerB, double sideA)
        {
            var sidesTriangle = FinderSidesTriangle.FindSides(cornerA, cornerB, sideA);

            SettingSides(sidesTriangle);
        }

        private void SettingSides(double[] sidesTriangle)
        {
            if (sidesTriangle.Length != 0)
            {
                this.SideA = sidesTriangle[0];
                this.SideB = sidesTriangle[1];
                this.SideC = sidesTriangle[2];
            }
        }

        public double AreaCalculation()
        {
            double perimeter;
            perimeter = (this.SideA + this.SideB + this.SideC) / 2;           

            if (perimeter != 0)
                this.area = Math.Sqrt(perimeter * (perimeter - SideA) * (perimeter - SideB) * (perimeter - SideC));

            return this.area;
        }       
    }
}
