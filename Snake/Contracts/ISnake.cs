using SnakeGame.Models;
using System.Collections.Generic;

namespace SnakeGame.Contracts
{
    public interface ISnake
    {
        Queue<Position> SnakeElements { get; }
        bool IsAlive { get; }
        void Move(int direction, ILevel currentLevel, IList<IObstacle> Obstacles);
        bool SnakeBitesItself(Position snakeNewHead);
        bool SnakeHitsBorder(Position snakeNewHead);
        //void Print();
    }
}
