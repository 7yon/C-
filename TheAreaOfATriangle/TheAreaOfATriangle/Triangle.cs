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

        private Triangle(double edgeA, double edgeB, double edgeC)
        {
            this.edgeA = edgeA;
            this.edgeB = edgeB;
            this.edgeC = edgeC;

            this.CalculateArea();
        }

        public static Triangle FromThreeSides(double edgeA, double edgeB, double edgeC)
        {
            if (IsValidThreeSides(edgeA, edgeB, edgeC))
            {
                Triangle triangle = new Triangle(edgeA, edgeB, edgeC);
                return triangle;
            }
            else
                throw new ArgumentException("Не выполняется правило: Сумма двух любых сторон всегда больше третьей стороны\n");
        }

        public static Triangle FromTwoSidesAndAngle(double edgeA, double edgeB, double angle)
        {
            if (IsValidTwoSidesAndAgle(edgeA, edgeB, angle))
            {
                double edgeC = Math.Sqrt(Math.Pow(edgeA, 2) + Math.Pow(edgeB, 2) - 2 * edgeA * edgeB * Math.Cos(DegreeToRadian(angle)));

                Triangle triangle = new Triangle(edgeA, edgeB, edgeC);
                return triangle;
            } 
            else
                throw new ArgumentException("Не выполняется одно или оба из правил: Стороны всегда принимают положительные значения и сумма двух углов всегда меньше 180 градусов\n");
        }

        public static Triangle FromTwoAglesAndSide(double angleA, double angleB, double edgeA)
        {         
            if (IsValidTwoAglesAndSide(angleA, angleB, edgeA))
            {
                double angleS = 180 - angleA - angleB;
                double dependenceSides = edgeA / Math.Sin(DegreeToRadian(angleS));

                double edgeB = Math.Sin(DegreeToRadian(angleB)) * dependenceSides;
                double edgeC = Math.Sin(DegreeToRadian(angleA)) * dependenceSides;

                Triangle triangle = new Triangle(edgeA, edgeB, edgeC);
                return triangle;
            }            
            else
                throw new ArgumentException("Не выполняется правило: Сумма двух углов меньше 180 градусов\n");
        }

        private static bool IsValidThreeSides(double edgeA, double edgeB, double edgeC)
        {
            if ((edgeA + edgeB > edgeC) && (edgeA + edgeC > edgeB) && (edgeC + edgeB > edgeA))
            {
                return true;
            }
            else
                return false;
        }

        private static bool IsValidTwoSidesAndAgle(double edgeA, double edgeB, double agle)
        {
            if ((agle > 0 && agle < 180) && (edgeA > 0) && (edgeB > 0))
            {
                return true;
            }
            else
                return false;
        }

        private static bool IsValidTwoAglesAndSide(double angleA, double angleB, double edgeA)
        {
            if (angleA + angleB < 180)
            {
                return true;
            }
            else
                return false;
      }

        private void CalculateArea()
        {
            double perimeter = (this.edgeA + this.edgeB + this.edgeC) / 2;           
            this.Area = Math.Sqrt(perimeter * (perimeter - edgeA) * (perimeter - edgeB) * (perimeter - edgeC));  
        }

        private static double DegreeToRadian(double degree)
        {
            return degree / 180.0 * Math.PI;
        }
    }
}
