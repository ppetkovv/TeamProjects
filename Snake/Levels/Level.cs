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

        public int SlowActionGame { get => this.slowActionGame; private set => this.slowActionGame = value; }
        public int InitialSnakeLevelLength { get => this.initialSnakeLevelLength;  private set => this.initialSnakeLevelLength = value;}
        public IApple Apple { get => this.apple;}
        public int ApplesTarget {get => this.applesTarget; private set => this.applesTarget = value; }
        public int LastAppleCreationTime { get => this.lastAppleCreationTime; private set => this.lastAppleCreationTime = value;}
        public int NegativePointsPerMissedApple { get => this.negativePointsPerMissedApple; private set => this.negativePointsPerMissedApple = value;}
        public int AllLevelPoints => this.levelPoints.AllPoints;
        public IList<IObstacle> Obstacles => this.obstacles;
        public int CurrentlyEatenApples { get => this.currentlyEatenApples;
            set
            {
                if (value != this.currentlyEatenApples + 1)
                {
                    throw new ArgumentException(Constants.InvalidApplesState);
                }
                this.currentlyEatenApples = value;
            }
        }

        private IPosition GenerateRandomPosition()
        {
            Random row = new Random();
            Random col = new Random();

            var randomPosition = new Position(row.Next(2, Console.WindowHeight - 3),
                                              col.Next(2, Console.WindowWidth - 3));
            return randomPosition;
        }

        public void GenerateApple()
        {
            if (this.Apple != null)
            {
                Apple.EraseApple();
            }
            IPosition newAppleCoordinates = this.GenerateRandomPosition();
            this.apple = new Apple(newAppleCoordinates.Row, newAppleCoordinates.Col);
            this.apple.PrintApple();
            this.LastAppleCreationTime = Environment.TickCount;
        }

        public void GenerateObstacle()
        {
            IPosition newObstacleCoordinates = this.GenerateRandomPosition();
            Obstacle obstacle = new Obstacle(newObstacleCoordinates.Row, newObstacleCoordinates.Col);
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