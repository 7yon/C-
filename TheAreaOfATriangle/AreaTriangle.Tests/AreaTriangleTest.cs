using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AreaTriangle.Tests
{
    [TestClass]
    public class AreaTriangleTest
    {
        [TestMethod]
        public void RightAreaAndSidesTriangle()
        {
            var a = 3;
            var b = 4;
            var corner = "90d";

            Triangle triangle = new Triangle(a, b, corner);

            Assert.AreEqual(6, triangle.AreaCalculation());
            Assert.AreEqual(3, triangle.SideA);
            Assert.AreEqual(4, triangle.SideB);
            Assert.AreEqual(5, triangle.SideC);
        }
    }
}
