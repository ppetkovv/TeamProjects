using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnakeGame.Contracts;
using SnakeGame.Models;

namespace SnakeEngine.UnitTests.Models.PointsTesting
{
    [TestClass]
    public class PointsProperty_Should
    {
        [TestMethod]
        public void SetsAndGetsPositivePoints_WhenInvoked()
        {
            //Arrange
            int snakeInitialLength = 10;
            IPoints points = new Points(snakeInitialLength);

            //Act & Assert
            points.PositivePoints = 100;
            Assert.AreEqual(100, points.PositivePoints);
        }

        [TestMethod]
        public void SetsAndGetsNegativePoints_WhenInvoked()
        {
            //Arrange
            int snakeInitialLength = 10;
            IPoints points = new Points(snakeInitialLength);

            //Act & Assert
            points.NegativePoints = 100;
            Assert.AreEqual(100, points.NegativePoints);
        }

        [TestMethod]
        public void ReturnCorrectResultOfAllPoints_WhenInvoked()
        {
            //Arrange
            int snakeInitialLength = 10;
            IPoints points = new Points(snakeInitialLength);
            points.PositivePoints = 100;
            points.NegativePoints = 10;

            //Act & Assert
            Assert.AreEqual(90, points.AllPoints);
        }
    }
}