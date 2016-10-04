using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FifteenPuzzle.Tests
{
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Game_TryCreateImpossiblePlayingFieldWithIncorrectDimension_MustThrowException()
        {
            Game game = new Game(1, 2, 3, 4, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Game_TryCreateImpossiblePlayingFieldWithIncorrectNumberCells_MustThrowException()
        {
            Game game = new Game(1, 2, 2, 4, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Game_TryCreateImpossiblePlayingFieldWithIncorrectCellValues_MustThrowException()
        {
            Game game = new Game(1, 2, 2, 4, 8, 5, 6, 7, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Game_TryMoveCellWhereThereNoZero_MustThrowException()
        {
            Game game = new Game(1, 2, 3, 0, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);

            game.Shift(14);
        }
    }
}
