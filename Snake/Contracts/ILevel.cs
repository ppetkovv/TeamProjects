using System.Collections.Generic;

namespace SnakeGame.Contracts
{
    public interface ILevel
    {
        int SlowActionGame { get; }

        int InitialSnakeLevelLength { get; }

        IApple Apple { get; }
        void GenerateApple(IList<IObstacle> obstacles);
        int ApplesTarget { get; }
        int CurrentlyEatenApples { get; set; }
        void CheckForAppleTimeElapsed(IList<IObstacle> obstacles);
        int LastAppleCreationTime { get; }
        
        int AllLevelPoints { get; }
        void AddPoints();
        int NegativePointsPerMissedApple { get; }

        void GenerateObstacle();
        IList<IObstacle> Obstacles { get; }
    }
}