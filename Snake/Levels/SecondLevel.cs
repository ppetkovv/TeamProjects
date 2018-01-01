namespace SnakeGame.Levels
{
    public class SecondLevel : Level
    {
        private const int slowActionGameInMilliseconds = 45;
        private const int snakeSecondLevelLength = 6;
        private const int applesTargetCount = 5;
        private const int negativePointsPerMissedApple = 55;

        public SecondLevel() : 
            base(slowActionGameInMilliseconds, snakeSecondLevelLength, applesTargetCount, negativePointsPerMissedApple)
        {
        }
    }
}