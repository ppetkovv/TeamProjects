namespace SnakeGame.Levels
{
    public class FourthLevel : Level
    {
        private const int SlowActionGameInMilliseconds = 35;
        private const int SnakeFourthLevelLength = 8;
        private const int ApplesTargetCount = 9;
        private const int NegativePointsPerMissedApple = 65;

        public FourthLevel() : 
            base(SlowActionGameInMilliseconds, SnakeFourthLevelLength, ApplesTargetCount, NegativePointsPerMissedApple)
        {
        }
    }
}