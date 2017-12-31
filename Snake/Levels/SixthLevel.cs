namespace SnakeGame.Levels
{
    public class SixthLevel : Level
    {
        private const int SlowActionGameInMilliseconds = 30;
        private const int SnakeSixthLevelLength = 10;
        private const int ApplesTargetCount = 13;
        private const int NegativePointsPerApple = 75;

        public SixthLevel() : 
            base(SlowActionGameInMilliseconds, SnakeSixthLevelLength, ApplesTargetCount, NegativePointsPerApple)
        {
        }
    }
}
