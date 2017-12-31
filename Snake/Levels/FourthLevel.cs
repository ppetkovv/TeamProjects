namespace SnakeGame.Levels
{
    public class FourthLevel : Level
    {
        private const int slowActionGameInMilliseconds = 35;
        private const int snakeFourthLevelLength = 8;
        private const int applesTargetCount = 9;
        private const int negativePointsPerApple = 65;

        public FourthLevel() : 
            base(slowActionGameInMilliseconds, snakeFourthLevelLength, applesTargetCount, negativePointsPerApple)
        {
        }
    }
}