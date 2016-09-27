using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Triangle.Tests
{
    [TestClass]
    public class TriangleTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
        "Не выполняется правило: Сумма двух любых сторон всегда больше третьей стороны\n")]
        public void Triangle_TryCreateImpossibleTriangleWithIncorrectSides_MustThrowException()
        {
            var edgeA = 1;
            var edgeB = 4;
            var edgeC = 9;
            
            var area = AreaTriangle.Triangle.FromThreeSides(edgeA, edgeB, edgeC);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
        "Не выполняется одно или оба из правил: Стороны всегда принимают положительные значения и сумма двух углов всегда меньше 180 градусов\n")]
        public void Triangle_TryCreateImpossibleTriangleWithReflexAngle_MustThrowException()
        {
            var edgeA = 8.9;
            var edgeB = 3.9;
            var agle = 190;

            var area = TheAreaOfATriangle.Triangle.FromTwoSidesAndAngle(edgeA, edgeB, agle);          
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
        "Не выполняется правило: Сумма двух углов меньше 180 градусов\n")]      
        public void Triangle_TryCreateImpossibleTriangleWithTwoReflexAngles_MustThrowException()
        {
            var edgeA = 5;
            var agleA = 92;
            var agleB = 127;

            var area = TheAreaOfATriangle.Triangle.FromTwoAglesAndSide(agleA, agleB, edgeA);
        }

        [TestMethod]
        public void Triangle_CalculationCorrectArea()
        {
            var edgeA = 3;
            var edgeB = 4;
            var agle = 90;

            var area = TheAreaOfATriangle.Triangle.FromTwoSidesAndAngle(edgeA, edgeB, agle).Area;
        }
    }
}
