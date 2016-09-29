using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAreaOfATriangle
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
            if (triangle.IsValidThreeSides(edgeA, edgeB, edgeC))
            {
                triangle.edgeA = edgeA;
                triangle.edgeB = edgeB;
                triangle.edgeC = edgeC;
            }

            triangle.CalculateArea();
            return triangle;
        }

        public static Triangle FromTwoSidesAndAngle(double edgeA, double edgeB, double angle)
        {
            Triangle triangle = new Triangle();
            if(triangle.IsValidTwoSidesAndAgle(edgeA, edgeB, angle))
            {
                double sideC = Math.Sqrt(Math.Pow(edgeA, 2) + Math.Pow(edgeB, 2) - 2 * edgeA * edgeB * Math.Cos(DegreeToRadian(agle)));

                triangle.edgeA = edgeA;
                triangle.edgeB = edgeB;
                triangle.edgeC = sideC;
            }

            triangle.CalculateArea();
            return triangle;
        }

        public static Triangle FromTwoAglesAndSide(double angleA, double angleB, double edgeA)
        {
            Triangle triangle = new Triangle();
            if (triangle.IsValidTwoAglesAndSide(angleA, angleB, edgeA))
            {
                double angleS = 180 - angleA - angleB;
                double dependenceSides = edgeA / Math.Sin(triangle.DegreeToRadian(angleS));

                double sideB = Math.Sin(triangle.DegreeToRadian(angleB)) * dependenceSides;
                double sideC = Math.Sin(triangle.DegreeToRadian(angleA)) * dependenceSides;

                triangle.edgeA = edgeA;
                triangle.edgeB = sideB;
                triangle.edgeC = sideC;
            }

            triangle.CalculateArea();
            return triangle;
        }

        private bool IsValidThreeSides(double edgeA, double edgeB, double edgeC)
        {
            if ((edgeA + edgeB > edgeC) && (edgeA + edgeC > edgeB) && (edgeC + edgeB > edgeA))
            {
                return true;
            }
            else throw new ArgumentException("Не выполняется правило: Сумма двух любых сторон всегда больше третьей стороны\n");
        }

        private bool IsValidTwoSidesAndAgle(double edgeA, double edgeB, double agle)
        {            
            if ((agle > 0 && agle < 180) && (edgeA > 0) && (edgeB > 0))
            {
                return true;
            }        
            else throw new ArgumentException("Не выполняется одно или оба из правил: Стороны всегда принимают положительные значения и сумма двух углов всегда меньше 180 градусов\n");
        }

        private bool IsValidTwoAglesAndSide(double angleA, double angleB, double edgeA)
        {
            if (angleA + angleB < 180)
            {
                return true;
            }
            else throw new ArgumentException("Не выполняется правило: Сумма двух углов меньше 180 градусов\n");
      }

        private void CalculateArea()
        {
            double perimeter = (this.edgeA + this.edgeB + this.edgeC) / 2;           
            this.Area = Math.Sqrt(perimeter * (perimeter - edgeA) * (perimeter - edgeB) * (perimeter - edgeC));  
        }

        public double DegreeToRadian(double degree)
        {
            return degree / 180.0 * Math.PI;
        }
    }
}
