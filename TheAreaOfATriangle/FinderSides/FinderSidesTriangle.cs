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
            else return new double[] { };
        }
        public static double[] FindSides(double sideA, double sideB, string corner)
        {
            corner = corner.Remove(corner.Length - 1);
            double cornerDouble = Double.Parse(corner);

            if ((cornerDouble > 0 && cornerDouble < 180) && (sideA > 0) && (sideB > 0))
            {
                double sideC;
                sideC = Math.Sqrt(Math.Pow(sideA, 2) + Math.Pow(sideB, 2) - 2 * sideA * sideB * Math.Cos(cornerDouble));

                return new double[] { sideA, sideB, sideC };
            }
            else return new double[] { };
        }
        public static double[] FindSides(string cornerA, string cornerB, double sideA)
        {

            cornerA = cornerA.Remove(cornerA.Length - 1);
            cornerB = cornerB.Remove(cornerB.Length - 1);

            double cornerADouble = Double.Parse(cornerA);
            double cornerBDouble = Double.Parse(cornerB);

            if (cornerADouble + cornerBDouble < 180)
            {
                double cornerCDouble = 180 - cornerADouble - cornerBDouble;

                double dependenceSides;
                dependenceSides = sideA / cornerCDouble;

                return new double[] { sideA, cornerBDouble / dependenceSides, cornerCDouble / dependenceSides };
            }
            else return new double[] { };
        }
    }
}
