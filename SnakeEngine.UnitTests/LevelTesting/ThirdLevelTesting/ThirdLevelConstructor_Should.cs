using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnakeGame.Contracts;
using SnakeGame.Levels;

namespace SnakeEngine.UnitTests.LevelTesting.ThirdLevelTesting
{
    [TestClass]
    public class ThirdLevelConstructor_Should
    {
        [TestMethod]
        public void SetCorrectSlowActionTime_WhenInvoked()
        {
            //Arrange
            int thirdLevelSlowActionGameInMilliseconds = 30;
            ILevel thirdLevel = new ThirdLevel();

            //Act & Assert
            Assert.AreEqual(thirdLevelSlowActionGameInMilliseconds, thirdLevel.SlowActionGame);
        }

        [TestMethod]
        public void SetInitialSnakeLengthForLevel_WhenInvoked()
        {
            //Arrange
            int snakeThirdLevelLength = 12;
            ILevel thirdLevel = new ThirdLevel();

            //Act & Assert
            Assert.AreEqual(snakeThirdLevelLength, thirdLevel.InitialSnakeLevelLength);
        }

        [TestMethod]
        public void SetApplesTargetCountForLevel_WhenInvoked()
        {
            //Arrange
            int applesTargetCount = 7;
            ILevel thirdLevel = new ThirdLevel();

            //Act & Assert
            Assert.AreEqual(applesTargetCount, thirdLevel.ApplesTarget);
        }

        [TestMethod]
        public void SetNegativePointsPerMissedAppleForLevel_WhenInvoked()
        {
            //Arrange
            int negativePointsPerMissedApple = 60;
            ILevel thirdLevel = new ThirdLevel();

            //Act & Assert
            Assert.AreEqual(negativePointsPerMissedApple, thirdLevel.NegativePointsPerMissedApple);
        }
    }
}