using SnakeGame.Models;
using System.Collections.Generic;

namespace SnakeGame.Contracts
{
    public interface ILevel
    {
        int SlowActionGame { get; }
        int InitialSnakeLevelLength { get; }
        int ApplesToBeEaten { get; }
        int CurrentlyEatenApples { get; set; }
        Position ApplePosition { get; }
        void GenerateApple();
        //////////
        int LastAppleCreationTime { get; }
        int NegativePointsPerMissedApple { get; }
        int AllLevelPoints { get; }
        void AddPoints();
        void CheckForAppleTimeElapsed();
    }
}