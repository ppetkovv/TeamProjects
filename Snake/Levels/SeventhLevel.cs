namespace SnakeGame.Levels
{
    public class SeventhLevel : Level
    {
        private const int slowActionGameInMilliseconds = 30;
        private const int snakeSeventhLevelLength = 11;
        private const int applesTargetCount = 15;
        private const int negativePointsPerApple = 80;

        public SeventhLevel() : 
            base(slowActionGameInMilliseconds, snakeSeventhLevelLength, applesTargetCount, negativePointsPerApple)
        {
        }
    }
}