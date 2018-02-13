using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnakeGame.Contracts;
using SnakeGame.Levels;

namespace SnakeEngine.UnitTests.LevelTesting.SecondLevelTesting
{
    [TestClass]
    public class SecondLevelConstructor_Should
    {
        [TestMethod]
        public void SetCorrectSlowActionTime_WhenInvoked()
        {
            //Arrange
            int secondLevelSlowActionGameInMilliseconds = 40;
            ILevel secondLevel = new SecondLevel();

            //Act & Assert
            Assert.AreEqual(secondLevelSlowActionGameInMilliseconds, secondLevel.SlowActionGame);
        }

        [TestMethod]
        public void SetInitialSnakeLengthForLevel_WhenInvoked()
        {
            //Arrange
            int snakeSecondLevelLength = 10;
            ILevel secondLevel = new SecondLevel();

            //Act & Assert
            Assert.AreEqual(snakeSecondLevelLength, secondLevel.InitialSnakeLevelLength);
        }

        [TestMethod]
        public void SetApplesTargetCountForLevel_WhenInvoked()
        {
            //Arrange
            int applesTargetCount = 5;
            ILevel secondLevel = new SecondLevel();

            //Act & Assert
            Assert.AreEqual(applesTargetCount, secondLevel.ApplesTarget);
        }

        [TestMethod]
        public void SetNegativePointsPerMissedAppleForLevel_WhenInvoked()
        {
            //Arrange
            int negativePointsPerMissedApple = 55;
            ILevel secondLevel = new SecondLevel();

            //Act & Assert
            Assert.AreEqual(negativePointsPerMissedApple, secondLevel.NegativePointsPerMissedApple);
        }
    }
}