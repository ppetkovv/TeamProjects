using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Levels
{
    class FourthLevel : Level
    {
        private const int NegativePointsPerApple = 65;
        private const int SlowActionGameInMilliseconds = 35;
        private const int SnakeFourthLevelLength = 8;
        private const int ApplesTargetCount = 9;

        public FourthLevel() : base(SlowActionGameInMilliseconds,SnakeFourthLevelLength,ApplesTargetCount,NegativePointsPerApple)
        {
        }
    }
}