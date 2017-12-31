namespace SnakeGame.Levels
{
    public class SeventhLevel : Level
    {
        private const int SlowActionGameInMilliseconds = 30;
        private const int SnakeSeventhLevelLength = 11;
        private const int ApplesTargetCount = 15;
        private const int NegativePointsPerApple = 80;

        public SeventhLevel() : 
            base(SlowActionGameInMilliseconds, SnakeSeventhLevelLength, ApplesTargetCount, NegativePointsPerApple)
        {
        }
    }
}