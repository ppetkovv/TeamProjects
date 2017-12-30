using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Levels
{
    class NinethLevel : Level
    {
        private const int NegativePointsPerApple = 90;
        private const int SlowActionGameInMilliseconds = 30;
        private const int SnakeNinethLevelLength = 13;
        private const int ApplesTargetCount = 19;

        public NinethLevel() : base(SlowActionGameInMilliseconds, SnakeNinethLevelLength, ApplesTargetCount, NegativePointsPerApple)
        {
        }
    }
}