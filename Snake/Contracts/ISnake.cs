using SnakeGame.Models;
using System.Collections.Generic;

namespace SnakeGame.Contracts
{
    public interface ISnake
    {
        Queue<Position> SnakeElements { get; }
        bool IsAlive { get; }
        void Move(int direction, ILevel currentLevel);
        void SnakeBitesItself(Position snakeNewHead);
        void SnakeHitsBorder(Position snakeNewHead);
        //void Print();
    }
}
