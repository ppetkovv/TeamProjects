using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnakeGame.Contracts;
using SnakeGame.Levels;

namespace SnakeEngine.UnitTests.LevelTesting.FirstLevelTesting
{
    [TestClass]
    public class FirstLevelConstructor_Should
    {
        [TestMethod]
        public void SetCorrectSlowActionTime_WhenInvoked()
        {
            //Arrange
            int firstLevelSlowActionGameInMilliseconds = 50;
            ILevel firstLevel = new FirstLevel();

            //Act & Assert
            Assert.AreEqual(firstLevelSlowActionGameInMilliseconds, firstLevel.SlowActionGame);
        }

        [TestMethod]
        public void SetInitialSnakeLengthForLevel_WhenInvoked()
        {
            //Arrange
            int snakeFirstLevelLength = 7;
            ILevel firstLevel = new FirstLevel();

            //Act & Assert
            Assert.AreEqual(snakeFirstLevelLength, firstLevel.InitialSnakeLevelLength);
        }

        [TestMethod]
        public void SetApplesTargetCountForLevel_WhenInvoked()
        {
            //Arrange
            int applesTargetCount = 3;
            ILevel firstLevel = new FirstLevel();

            //Act & Assert
            Assert.AreEqual(applesTargetCount, firstLevel.ApplesTarget);
        }

        [TestMethod]
        public void SetNegativePointsPerMissedAppleForLevel_WhenInvoked()
        {
            //Arrange
            int negativePointsPerMissedApple = 50;
            ILevel firstLevel = new FirstLevel();

            //Act & Assert
            Assert.AreEqual(negativePointsPerMissedApple, firstLevel.NegativePointsPerMissedApple);
        }
    }
}