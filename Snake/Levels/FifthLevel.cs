namespace SnakeGame.Levels
{
    public class FifthLevel : Level
    {
        private const int slowActionGameInMilliseconds = 30;
        private const int snakeFifthLevelLength = 9;
        private const int applesTargetCount = 11;
        private const int negativePointsPerMissedApple = 70;

        public FifthLevel() : 
            base(slowActionGameInMilliseconds, snakeFifthLevelLength, applesTargetCount, negativePointsPerMissedApple)
        {
        }
    }
}