using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AreaTriangle.Tests
{
    [TestClass]
    public class AreaTriangleTest
    {
        [TestMethod]
        public void RightAreaTriangle()
        {
            var a = 3;
            var b = 4;
            var c = 5;

            Triangle triangle = new Triangle(1, 3, 6);

            Assert.AreEqual(0, triangle.AreaCalculation());
        }
    }
}
