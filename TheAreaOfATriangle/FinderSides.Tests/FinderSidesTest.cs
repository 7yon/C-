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
            var a = 1;
            var b = 4;
            var c = 9;
         
            var area = FinderSidesTriangle.CheckSides(a, b, c);

            Assert.AreEqual(0, area.Length);
        }

        [TestMethod]
        public void OneBigCorner()
        {
            var a = 4;
            var b = 9;
            var corner = "193d";

            var area = FinderSidesTriangle.FindSides(a, b, corner);
            Assert.AreEqual(0, area.Length);
        }

        [TestMethod]
        public void TwoBigCorners()
        {
            var a = 12;
            var cornerA = "92d";
            var cornerB = "100d";

            var area = FinderSidesTriangle.FindSides(cornerA, cornerB, a);
            Assert.AreEqual(0, area.Length);
        }
    }
}
