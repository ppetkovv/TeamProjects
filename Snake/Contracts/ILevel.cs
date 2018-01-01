using System.Collections.Generic;

namespace SnakeGame.Contracts
{
    public interface ILevel
    {
        int SlowActionGame { get; }
        int InitialSnakeLevelLength { get; }
        int ApplesTarget { get; }
        int CurrentlyEatenApples { get; set; }
        IApple Apple { get; }
        int LastAppleCreationTime { get; }
        int NegativePointsPerMissedApple { get; }
        int AllLevelPoints { get; }
        void AddPoints();
        void GenerateApple();
        void GenerateObstacle();
        void CheckForAppleTimeElapsed();
        IList<IObstacle> Obstacles { get; }
    }
}