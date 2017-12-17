using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake.Engine;

namespace Snake
{
    class Startup
    {
        static void Main(string[] args)
        {
            SnakeEngine.Instance.Start();
        }
    }
}