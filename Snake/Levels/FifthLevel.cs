using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Levels
{
    class FifthLevel : Level
    {
        private const int NegativePointsPerApple = 70;
        private const int SlowActionGameInMilliseconds = 30;
        private const int SnakeFifthLevelLength = 9;
        private const int ApplesTargetCount = 11;


        public FifthLevel() : base(SlowActionGameInMilliseconds, SnakeFifthLevelLength,ApplesTargetCount,NegativePointsPerApple)
        {
        }
    }
}