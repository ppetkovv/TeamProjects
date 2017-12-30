using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Levels
{
    class TenthLevel : Level
    {
        private const int NegativePointsPerApple = 95;
        private const int SlowActionGameInMilliseconds = 30;
        private const int SnakeTenthLevelLength = 14;
        private const int ApplesTargetCount = 21;

        public TenthLevel() : base(SlowActionGameInMilliseconds, SnakeTenthLevelLength, ApplesTargetCount, NegativePointsPerApple)
        {
        }
    }
}