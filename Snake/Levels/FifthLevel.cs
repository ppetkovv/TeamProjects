namespace SnakeGame.Levels
{
    public class FifthLevel : Level
    {
        private const int SlowActionGameInMilliseconds = 30;
        private const int SnakeFifthLevelLength = 9;
        private const int ApplesTargetCount = 11;
        private const int NegativePointsPerMissedApple = 70;
        
        public FifthLevel() : 
            base(SlowActionGameInMilliseconds, SnakeFifthLevelLength, ApplesTargetCount, NegativePointsPerMissedApple)
        {
        }
    }
}