namespace SnakeGame.Levels
{
    public class SecondLevel : Level
    {
        private const int slowActionGameInMilliseconds = 40;
        private const int snakeSecondLevelLength = 10;
        private const int applesTargetCount = 5;
        private const int negativePointsPerMissedApple = 55;

        public SecondLevel() : 
            base(slowActionGameInMilliseconds, snakeSecondLevelLength, applesTargetCount, negativePointsPerMissedApple)
        {
        }
    }
}