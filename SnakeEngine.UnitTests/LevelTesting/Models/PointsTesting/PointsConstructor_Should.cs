using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnakeGame.Contracts;
using SnakeGame.Models;

namespace SnakeEngine.UnitTests.Models.PointsTesting
{
    [TestClass]
    public class PointsConstructor_Should
    {
        [TestMethod]
        public void ThrowArgumentException_WhenNegativeArgumentIsPassed()
        {
            //Arrange, Act & Assert
            int snakeInitialLength = -10;
            Assert.ThrowsException<ArgumentException>(() => new Points(snakeInitialLength));
        }

        [TestMethod]
        public void SetInitialSnakeLength_WhenInvokedWithCorrectArguments()
        {
            //Arrange
            int snakeInitialLength = 5;
            IPoints points = new Points(snakeInitialLength);

            //Act & Assert
            Assert.AreEqual(5, points.SnakeInitialLength);
        }
    }
}