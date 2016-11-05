using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq.Expressions;
using Application;

namespace AlgebraicExpressionTests
{
    [TestClass]
    public class AlgebraicExpressionTest
    {
        [TestMethod]
        public void SimpleTest()
        {
            Expression<Func<double, double>> f = x => x * x;
            Func<double, double> df = f.Differentiate();
           
            double result = df.Invoke(12);

            Assert.AreEqual(24, result);
        }

        [TestMethod]
        public void SinTest()
        {
            Expression<Func<double, double>> f = x => (10 + Math.Sin(x)) * x;
            Func<double, double> df = f.Differentiate();

            double result = df.Invoke(12);

            Assert.AreEqual(Math.Round(19.5896745867895, 3), Math.Round(result, 3));
        }
    }
}
