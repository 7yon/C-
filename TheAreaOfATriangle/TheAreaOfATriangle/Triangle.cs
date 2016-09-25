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
        private double sideA = 0, sideB = 0, sideC = 0;
        private double area = 0;

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

        public double AreaCalculation() {
            double perimeter;
            perimeter = (this.sideA + this.sideB + this.sideC) / 2;           

            if (perimeter != 0)
                this.area = Math.Sqrt(perimeter * (perimeter - sideA) * (perimeter - sideB) * (perimeter - sideC));
            return this.area;
        }
        private void SettingSides(double[] sidesTriangle)
        {
            if (sidesTriangle.Length != 0)
            {
                this.sideA = sidesTriangle[0];
                this.sideB = sidesTriangle[1];
                this.sideC = sidesTriangle[2];
            }
        }
    }
}
