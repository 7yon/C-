using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FifteenPuzzle.Tests
{
    [TestClass]
    public class ImmutableGameTest : GameTest
    {
        [TestInitialize]
        public new void Initialize()
        {
            game = new ImmutableGame(1, 2, 3, 0, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
        }

        [TestMethod]
        public void ImmutableGame_TryGetNewGameWithCorrectCoordinates_MustGetNewCorrectGame()
        {
            ImmutableGame game = new ImmutableGame(1, 2, 3, 0, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);

            ImmutableGame newGame = game.Shift(3);

            Assert.AreEqual(0, game[0, 3]);
            Assert.AreEqual(3, newGame[0, 3]);
            Assert.AreEqual(3, game[0, 2]);
            Assert.AreEqual(0, newGame[0, 2]);
        }
    }
}
