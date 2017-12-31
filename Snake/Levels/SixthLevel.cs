namespace SnakeGame.Levels
{
    public class SixthLevel : Level
    {
        private const int slowActionGameInMilliseconds = 30;
        private const int snakeSixthLevelLength = 10;
        private const int applesTargetCount = 13;
        private const int negativePointsPerApple = 75;

        public SixthLevel() : 
            base(slowActionGameInMilliseconds, snakeSixthLevelLength, applesTargetCount, negativePointsPerApple)
        {
        }
    }
}
