namespace SnakeGame.Levels
{
    public class FirstLevel : Level
    {
        private const int SlowActionGameInMilliseconds = 50;
        private const int SnakeFirstLevelLength = 5;
        private const int ApplesTargetCount = 3;
        private const int NegativePointsPerMissedApple = 50;

        public FirstLevel() : 
            base(SlowActionGameInMilliseconds, SnakeFirstLevelLength, ApplesTargetCount, NegativePointsPerMissedApple)
        {

        }
    }
}