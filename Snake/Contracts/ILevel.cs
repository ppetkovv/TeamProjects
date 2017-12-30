using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        void CheckForAppleTimeElapsed();
    }
}