using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe.GameLogic;

namespace TicTacToe.Tests
{
    [TestClass]
    public class GameResultValidatorTests
    {
        private readonly GameResultValidator validator = new GameResultValidator();

        [TestMethod]
        public void EmptyBoard_ShouldReturnNotFinished()
        {
            string board = "---------";

            var result = validator.GetResult(board);
            Assert.AreEqual(GameResult.NotFinished, result);
        }

        [TestMethod]
        public void NoWinner_ShouldReturnDraw()
        {
            string board = "XOXOOXOXO";

            var result = validator.GetResult(board);
            Assert.AreEqual(GameResult.Draw, result);
        }

        [TestMethod]
        public void WinByX_ShouldReturnWonByColX()
        {
            string board = "XOXOOXOXX";

            var result = validator.GetResult(board);
            Assert.AreEqual(GameResult.WonByX, result);
        }

        [TestMethod]
        public void WinByX_ShouldReturnWonByRowX()
        {
            string board = "XXXOOXOXX";

            var result = validator.GetResult(board);
            Assert.AreEqual(GameResult.WonByX, result);
        }

        [TestMethod]
        public void WinByX_ShouldReturnWonByColO()
        {
            string board = "XOXOO-XOO";

            var result = validator.GetResult(board);
            Assert.AreEqual(GameResult.WonByO, result);
        }

        [TestMethod]
        public void WinByX_ShouldReturnWonByRowO()
        {
            string board = "XOX--XOOO";

            var result = validator.GetResult(board);
            Assert.AreEqual(GameResult.WonByO, result);
        }

        [TestMethod]
        public void WinByX_ShouldReturnWonByLDiagX()
        {
            string board = "XOXOXOO-X";

            var result = validator.GetResult(board);
            Assert.AreEqual(GameResult.WonByX, result);
        }

        [TestMethod]
        public void WinByX_ShouldReturnWonByRDiagX()
        {
            string board = "XOXOXOXOO";

            var result = validator.GetResult(board);
            Assert.AreEqual(GameResult.WonByX, result);
        }
    }
}
