namespace SnakeGame.Levels
{
    public class ThirdLevel : Level
    {
        private const int SlowActionGameInMilliseconds = 40;
        private const int SnakeThirdLevelLength = 7;
        private const int ApplesTargetCount = 7;
        private const int NegativePointsPerMissedApple = 60;

        public ThirdLevel() : 
            base(SlowActionGameInMilliseconds, SnakeThirdLevelLength, ApplesTargetCount, NegativePointsPerMissedApple)
        {
        }
    }
}
