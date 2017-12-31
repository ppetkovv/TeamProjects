namespace SnakeGame.Levels
{
    public class ThirdLevel : Level
    {
        private const int slowActionGameInMilliseconds = 40;
        private const int snakeThirdLevelLength = 7;
        private const int applesTargetCount = 7;
        private const int negativePointsPerApple = 60;

        public ThirdLevel() : 
            base(slowActionGameInMilliseconds, snakeThirdLevelLength, applesTargetCount, negativePointsPerApple)
        {
        }
    }
}
