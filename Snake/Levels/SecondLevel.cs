namespace SnakeGame.Levels
{
    public class SecondLevel : Level
    {
        private const int SlowActionGameInMilliseconds = 45;
        private const int SnakeSecondLevelLength = 6;
        private const int ApplesTargetCount = 5;
        private const int NegativePointsPerMissedApple = 55;

        public SecondLevel() : 
            base(SlowActionGameInMilliseconds, SnakeSecondLevelLength, ApplesTargetCount, NegativePointsPerMissedApple)
        {
        }
    }
}