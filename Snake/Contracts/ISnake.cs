using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGame.Models;

namespace SnakeGame.Contracts
{
    public interface ISnake
    {
        Queue<Position> SnakeElements { get; }
        bool IsAlive { get; }
        void Move(int direction, ILevel currentLevel);
        //void Print();
    }
}
