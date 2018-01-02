namespace SnakeGame.Levels
{
    public class FirstLevel : Level
    {
        private const int slowActionGameInMilliseconds = 50;
        private const int snakeFirstLevelLength = 5;
        private const int applesTargetCount = 3;
        private const int negativePointsPerMissedApple = 50;

        public FirstLevel() : 
            base(slowActionGameInMilliseconds, snakeFirstLevelLength, applesTargetCount, negativePointsPerMissedApple)
        {
        }
    }
}