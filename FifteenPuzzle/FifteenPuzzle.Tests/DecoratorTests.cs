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
        public void Decorator_TryMoveIncorrectCellToZeroCell_MustThrowException()
        {
            Decorator game = decorator.Shift(99);
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
