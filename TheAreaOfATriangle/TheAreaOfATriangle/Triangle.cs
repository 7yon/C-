using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaTriangle
{
    public class Triangle 
    {
        public double edgeA { get; private set; }
        public double edgeB { get; private set; }
        public double edgeC { get; private set; }
        public double Area { get; private set; }

        public Triangle() { }

        public static Triangle FromThreeSides(double edgeA, double edgeB, double edgeC)
        {
            Triangle triangle = new Triangle();
            triangle.IsValidThreeSides(edgeA, edgeB, edgeC);

            return triangle;
        }

        public static Triangle FromTwoSidesAndAngle(double edgeA, double edgeB, double angle)
        {
            Triangle triangle = new Triangle();
            triangle.IsValidTwoSidesAndAgle(edgeA, edgeB, angle);

            return triangle;
        }

        public static Triangle FromTwoAglesAndSide(double angleA, double angleB, double edgeA)
        {
            Triangle triangle = new Triangle();
            triangle.IsValidTwoAglesAndSide(angleA, angleB, edgeA);

            return triangle;
        }

        public void IsValidThreeSides(double edgeA, double edgeB, double edgeC)
        {
            if ((edgeA + edgeB > edgeC) && (edgeA + edgeC > edgeB) && (edgeC + edgeB > edgeA))
            {
                this.edgeA = edgeA;
                this.edgeB = edgeB;
                this.edgeC = edgeC;
            }
            else throw new ArgumentException();
        }

        public void IsValidTwoSidesAndAgle(double edgeA, double edgeB, double agle)
        {            
            if ((agle > 0 && agle < 180) && (edgeA > 0) && (edgeB > 0))
            {
                double sideC = Math.Sqrt(Math.Pow(edgeA, 2) + Math.Pow(edgeB, 2) - 2 * edgeA * edgeB * Math.Cos(DegreeToRadian(agle)));

                this.edgeA = edgeA;
                this.edgeB = edgeB;
                this.edgeC = sideC;
            }        
            else throw new ArgumentException();
        }

        public void IsValidTwoAglesAndSide(double angleA, double angleB, double edgeA)
        {
            if (angleA + angleB < 180)
            {
                double angleS = 180 - angleA - angleB;
                double dependenceSides = edgeA / Math.Sin(DegreeToRadian(angleS));

                double sideB = Math.Sin(DegreeToRadian(angleB)) * dependenceSides;
                double sideC = Math.Sin(DegreeToRadian(angleA)) * dependenceSides;

                this.edgeA = edgeA;
                this.edgeB = sideB;
                this.edgeC = sideC;
            }
            else throw new ArgumentException();
      }

        public void CalculationArea()
        {
            double perimeter = (this.edgeA + this.edgeB + this.edgeC) / 2;           

            if (perimeter != 0)
                this.Area = Math.Sqrt(perimeter * (perimeter - edgeA) * (perimeter - edgeB) * (perimeter - edgeC));           
        }

        public double DegreeToRadian(double degree)
        {
            return degree / 180.0 * Math.PI;
        }
    }
}
