using System.Collections.Generic;

namespace SnakeGame.Contracts
{
    public interface ISnake
    {
        Queue<IPosition> SnakeElements { get; }

        void Move(string direction, ILevel currentLevel, IList<IObstacle> Obstacles);

        bool IsAlive { get; }
    }
}