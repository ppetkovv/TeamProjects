using SnakeGame.Common;
using SnakeGame.Contracts;
using SnakeGame.Models;
using System;
using System.Threading;

namespace SnakeGame.Levels
{
    public class Level : ILevel
    {
        private const int appleDissapearTimeInMilliseconds = 10000;
        private int slowActionGame;
        private int initialSnakeLevelLength;
        private int applesTarget;
        private int currentlyEatenApples;
        private IApple apple;
        private IObstacle obstacle;
        private IPoints levelPoints;
        private int lastAppleCreationTime = 0;
        private int negativePointsPerMissedApple;

        protected Level(int slowActionGame, int snakeLevelLength, int applesTarget, int negativePointsPerMissedApple)
        {
            this.SlowActionGame = slowActionGame;
            this.InitialSnakeLevelLength = snakeLevelLength;
            this.ApplesTarget = applesTarget;
            this.NegativePointsPerMissedApple = negativePointsPerMissedApple;
            this.levelPoints = new Points(snakeLevelLength);
        }

        public int SlowActionGame { get => this.slowActionGame; private set => this.slowActionGame = value; }
        public int InitialSnakeLevelLength { get => this.initialSnakeLevelLength; private set => this.initialSnakeLevelLength = value; }
        public int ApplesTarget { get => this.applesTarget; private set => this.applesTarget = value; }
        public int CurrentlyEatenApples { get => this.currentlyEatenApples; set { if (value != this.currentlyEatenApples + 1) { throw new ArgumentException(Constants.InvalidApplesState); } this.currentlyEatenApples = value; } }
        public IApple Apple { get => this.apple; }
        public IObstacle Obstacle { get => this.obstacle; }
        public int LastAppleCreationTime { get => this.lastAppleCreationTime; private set => this.lastAppleCreationTime = value; }
        public int NegativePointsPerMissedApple { get => this.negativePointsPerMissedApple; private set => this.negativePointsPerMissedApple = value; }
        public int AllLevelPoints => this.levelPoints.AllPoints;

        public void GenerateApple()
        {
            if (this.Apple != null)
            {
                Console.SetCursorPosition(this.Apple.AppleColPosition, this.Apple.AppleRowPosition);
                Console.Write(' ');     // LEAVES HOLES IN SNAKE WHEN IT EATS THE APPLE!
            }
            this.apple = new Apple();
            this.apple.PrintApple();
            this.LastAppleCreationTime = Environment.TickCount;
            
        }

        public void GenerateObstacle()
        {
            this.obstacle = new Obstacle();
            this.obstacle.PrintObstacle();
        }

        public void CheckForAppleTimeElapsed()
        {
            if (Environment.TickCount - this.LastAppleCreationTime >= appleDissapearTimeInMilliseconds)
            {
                this.levelPoints.NegativePoints += this.NegativePointsPerMissedApple;
                this.GenerateApple();
            }
        }

        public void AddPoints()
        {
            this.levelPoints.PositivePoints += 100;
        }
    }
}