using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Levels
{
    class EightLevel : Level
    {
        private const int NegativePointsPerApple = 85;
        private const int SlowActionGameInMilliseconds = 30;
        private const int SnakeEightLevelLength = 12;
        private const int ApplesTargetCount = 17;

        public EightLevel() : base(SlowActionGameInMilliseconds, SnakeEightLevelLength, ApplesTargetCount, NegativePointsPerApple)
        {
        }
    }
}