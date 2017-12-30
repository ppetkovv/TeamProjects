using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Levels
{
    class FirstLevel : Level
    {
        private const int NegativePointsPerApple = 50;
        private const int SlowActionGameInMilliseconds = 50;
        private const int SnakeFirstLevelLength = 5;
        private const int ApplesTargetCount = 3;

        public FirstLevel() : base(SlowActionGameInMilliseconds,SnakeFirstLevelLength,ApplesTargetCount,NegativePointsPerApple)
        {
        }
    }
}