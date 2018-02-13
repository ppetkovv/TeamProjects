using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnakeGame.Contracts;
using SnakeGame.Models;

namespace SnakeEngine.UnitTests.Models.PositionTesting
{
    [TestClass]
    public class PositionConstructor_Should
    {
        [TestMethod]
        public void SetPassedRowValueToProperty_WhenInvoked()
        {
            //Arrange
            int row = 5;
            int col = 15;
            IPosition position = new Position(row, col);

            //Act & Assert
            Assert.AreEqual(row, position.Row);
        }

        [TestMethod]
        public void SetPassedColValueToProperty_WhenInvoked()
        {
            //Arrange
            int row = 5;
            int col = 15;
            IPosition position = new Position(row, col);

            //Act & Assert
            Assert.AreEqual(col, position.Col);
        }
    }
}