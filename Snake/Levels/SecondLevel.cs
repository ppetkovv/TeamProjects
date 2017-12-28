using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Levels
{
    class SecondLevel : Level
    {
        private const int SlowActionGameInMilliseconds = 45;
        private const int SnakeSecondLevelLength = 6;
        private const int ApplesTargetCount = 5;

        public SecondLevel() : base(SlowActionGameInMilliseconds,SnakeSecondLevelLength,ApplesTargetCount)
        {
        }
    }
}