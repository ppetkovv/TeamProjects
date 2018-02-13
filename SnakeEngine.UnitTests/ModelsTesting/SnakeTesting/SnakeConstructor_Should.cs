using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnakeGame.Contracts;
using SnakeGame.Models;

namespace SnakeEngine.UnitTests.Models.SnakeTesting
{
    [TestClass]
    public class SnakeConstructor_Should
    {
        [TestMethod]
        public void InitializeSnakeWithCorrectLength_WhenLengthIsPresented()
        {
            //Arrange
            int snakeLength = 10;
            ISnake snake = new Snake(snakeLength);

            //Act & Assert
            Assert.AreEqual(10, snake.SnakeElements.Count);
        }

        [TestMethod]
        public void SetTheSnakeAsAlive_WhenInvoked()
        {
            //Arrange
            int snakeLength = 10;
            ISnake snake = new Snake(snakeLength);

            //Act & Assert
            Assert.IsTrue(snake.IsAlive);
        }
    }
}