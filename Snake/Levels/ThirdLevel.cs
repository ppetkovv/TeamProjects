using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Levels
{
    class ThirdLevel : Level
    {
        private const int SlowActionGameInMilliseconds = 40;
        private const int SnakeThirdLevelLength = 7;
        private const int ApplesTargetCount = 7;


        public ThirdLevel() : base(SlowActionGameInMilliseconds,SnakeThirdLevelLength,ApplesTargetCount)
        {
        }
    }
}
