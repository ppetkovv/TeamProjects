using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Levels
{
    class SeventhLevel : Level
    {
        private const int NegativePointsPerApple = 80;
        private const int SlowActionGameInMilliseconds = 30;
        private const int SnakeSeventhLevelLength = 11;
        private const int ApplesTargetCount = 15;

        public SeventhLevel() : base(SlowActionGameInMilliseconds, SnakeSeventhLevelLength, ApplesTargetCount,NegativePointsPerApple)
        {
        }
    }
}