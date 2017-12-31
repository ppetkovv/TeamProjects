﻿namespace SnakeGame.Levels
{
    public class FirstLevel : Level
    {
        private const int NegativePointsPerApple = 50;
        private const int SlowActionGameInMilliseconds = 50;
        private const int SnakeFirstLevelLength = 5;
        private const int ApplesTargetCount = 3;

        public FirstLevel() : 
            base(SlowActionGameInMilliseconds, SnakeFirstLevelLength, ApplesTargetCount, NegativePointsPerApple)
        {
        }
    }
}