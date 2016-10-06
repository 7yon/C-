using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FifteenPuzzle.Tests
{
    [TestClass]
    public class DecoratorTests : GameTest
    {
        Decorator decorator;

        [TestInitialize]
        public new void Initialize()
        {
            game = new ImmutableGame(1, 2, 3, 0, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
            decorator = new Decorator((ImmutableGame)game);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Decorator_TryGetCoordinatesOfIncorrectValue_MustThrowException()
        {
            Cell cell = decorator.GetLocation(23);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Decorator_TryGetValueOfIncorrectCoordinates_MustThrowException()
        {
            int value = decorator[7, 2];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Decorator_TryMoveIncorrectCellToZeroCell_MustThrowException()
        {
            Decorator game = decorator.Shift(99);
        }

        [TestMethod]
        public void Decorator_TryGetCoordinatesOfCorrectValue_MustGetCorrectCoordinates()
        {           
            Cell cell = decorator.GetLocation(6);

            Assert.AreEqual(1, cell.X);
            Assert.AreEqual(2, cell.Y);
        }

        [TestMethod]
        public void Decorator_TryGetValueOfCorrectCoordinates_MustGetValue()
        {
            int value = decorator[1, 2];

            Assert.AreEqual(6, value);
        }

        [TestMethod]
        public void Decorator_TryMoveCellToZeroCell_MustCorrectMoveCell()
        {

            Decorator game = decorator.Shift(3);

            Assert.AreEqual(0, game.GetLocation(3).X);
            Assert.AreEqual(3, game.GetLocation(3).Y);
        }
    }
}
