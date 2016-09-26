using System;
using FinderSides;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FinderSides.Tests
{
    [TestClass]
    public class FinderSidesTest
    {
        [TestMethod]
        public void NonExistentSideTriangle()
        {
            var sideA = 1;
            var sideB = 4;
            var sideC = 9;
         
            var area = FinderSidesTriangle.CheckSides(sideA, sideB, sideC);

            Assert.AreEqual(0, area.Length);
        }

        [TestMethod]
        public void OneBigCorner()
        {
            var sideA = 8.9;
            var sideB = 3.9;
            var corner = "190d";

            var area = FinderSidesTriangle.FindSides(sideA, sideB, corner);

            Assert.AreEqual(0, area.Length);
        }

        [TestMethod]
        public void TwoBigCorners()
        {
            var sideA = 5;
            var cornerA = "92d";
            var cornerB = "27d";

            
            var area = FinderSidesTriangle.FindSides(cornerA, cornerB, sideA);

            Assert.AreEqual(3, area.Length);
        }
    }
}
