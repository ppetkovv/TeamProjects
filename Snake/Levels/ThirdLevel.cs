namespace SnakeGame.Levels
{
    public class ThirdLevel : Level
    {
        private const int slowActionGameInMilliseconds = 30;
        private const int snakeThirdLevelLength = 12;
        private const int applesTargetCount = 7;
        private const int negativePointsPerMissedApple = 60;

        public ThirdLevel() : 
            base(slowActionGameInMilliseconds, snakeThirdLevelLength, applesTargetCount, negativePointsPerMissedApple)
        {
        }
    }
}
