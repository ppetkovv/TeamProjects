using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGame.Engine;

namespace SnakeGame
{
    class Startup
    {
        static void Main(string[] args)
        {
            SnakeEngine.Instance.Start();
        }
    }
}