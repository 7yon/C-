using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderSides
{
    public class FinderSidesTriangle
    {
        public static double[] CheckSides(double sideA, double sideB, double sideC)
        {
            if ((sideA + sideB > sideC) && (sideA + sideC > sideB) && (sideC + sideB > sideA))
            {
                return new double[] { sideA, sideB, sideC };
            }
            else
            {
                return new double[] { };
            }
        }
        public static double[] FindSides(double sideA, double sideB, string corner)
        {
            double doubleCorner;

            corner = corner.Remove(corner.Length - 1);
            doubleCorner = Double.Parse(corner);

            if ((doubleCorner > 0 && doubleCorner < 180) && (sideA > 0) && (sideB > 0))
            {
                double sideC;
                sideC = Math.Sqrt(Math.Pow(sideA, 2) + Math.Pow(sideB, 2) - 2 * sideA * sideB * Math.Cos(DegreeToRadian(doubleCorner)));

                return new double[] { sideA, sideB, sideC };
            }
            else
            {
                return new double[] { };
            }
        }
        public static double[] FindSides(string cornerA, string cornerB, double sideA)
        {
            cornerA = cornerA.Remove(cornerA.Length - 1);
            cornerB = cornerB.Remove(cornerB.Length - 1);

            double doubleCornerA = Double.Parse(cornerA);
            double doubleCornerB = Double.Parse(cornerB);

            if (doubleCornerA + doubleCornerB < 180)
            {
                double cornerCDouble;
                double dependenceSides;
                double sideB;
                double sideC;

                cornerCDouble = 180 - doubleCornerA - doubleCornerB;
                dependenceSides = sideA / Math.Sin(DegreeToRadian(cornerCDouble));

                sideB = Math.Sin(DegreeToRadian(doubleCornerB)) * dependenceSides;
                sideC = Math.Sin(DegreeToRadian(doubleCornerA)) * dependenceSides;

                return new double[] { sideA, sideB, sideC };
            }
            else
            {
                return new double[] { };
            }
        }
        public static double DegreeToRadian(double degree)
        {
            return degree / 180.0 * Math.PI;
        }
    }
}
