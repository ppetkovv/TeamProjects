using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Levels
{
    class SixthLevel : Level
    {
        private const int NegativePointsPerApple = 75;
        private const int SlowActionGameInMilliseconds = 30;
        private const int SnakeSixthLevelLength = 10;
        private const int ApplesTargetCount = 13;

        public SixthLevel() : base(SlowActionGameInMilliseconds, SnakeSixthLevelLength,ApplesTargetCount,NegativePointsPerApple)
        {
        }
    }
}
