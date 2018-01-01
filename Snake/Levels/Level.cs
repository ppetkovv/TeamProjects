using SnakeGame.Common;
using SnakeGame.Contracts;
using SnakeGame.Models;
using System;
using System.Collections.Generic;

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
        private IPoints levelPoints;
        private int lastAppleCreationTime = 0;
        private int negativePointsPerMissedApple;
        private IList<IObstacle> obstacles;

        protected Level(int slowActionGame, int snakeLevelLength, int applesTarget, int negativePointsPerMissedApple)
        {
            this.SlowActionGame = slowActionGame;
            this.InitialSnakeLevelLength = snakeLevelLength;
            this.ApplesTarget = applesTarget;
            this.NegativePointsPerMissedApple = negativePointsPerMissedApple;
            this.levelPoints = new Points(snakeLevelLength);
            this.obstacles = new List<IObstacle>();
        }

        public int SlowActionGame
        {
            get => this.slowActionGame;
            private set => this.slowActionGame = value;
        }

        public int InitialSnakeLevelLength
        {
            get => this.initialSnakeLevelLength;
            private set => this.initialSnakeLevelLength = value;
        }

        public int ApplesTarget
        {
            get => this.applesTarget;
            private set => this.applesTarget = value;
        }

        public int CurrentlyEatenApples
        {
            get => this.currentlyEatenApples;
            set
            {
                if (value != this.currentlyEatenApples + 1)
                {
                    throw new ArgumentException(Constants.InvalidApplesState);
                }
                this.currentlyEatenApples = value;
            }
        }

        public IApple Apple
        {
            get => this.apple;
        }

        public int LastAppleCreationTime
        {
            get => this.lastAppleCreationTime;
            private set => this.lastAppleCreationTime = value;
        }

        public int NegativePointsPerMissedApple
        {
            get => this.negativePointsPerMissedApple;
            private set => this.negativePointsPerMissedApple = value;
        }

        public int AllLevelPoints => this.levelPoints.AllPoints;
        
        public void GenerateApple()
        {
            if (this.Apple != null)
            {
                Apple.EraseApple();
            }
            this.apple = new Apple();
            this.apple.PrintApple();
            this.LastAppleCreationTime = Environment.TickCount;
        }

        public IList<IObstacle> Obstacles => this.obstacles;

        public void GenerateObstacle()
        {
            Obstacle obstacle = new Obstacle();
            Obstacles.Add(obstacle);
            obstacle.PrintObstacle();
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