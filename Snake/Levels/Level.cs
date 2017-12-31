using SnakeGame.Common;
using SnakeGame.Contracts;
using SnakeGame.Models;
using System;

namespace SnakeGame.Levels
{
    public   class Level : ILevel
    {
        private int slowActionGame;
        private int initialSnakeLevelLength;
        private int applesToBeEaten;
        private int currentlyEatenApples;
        private IApple apple;
        private const int appleDissapearTimeInMilliseconds = 10000;
        private IPoints levelPoints;
        private int lastAppleCreationTime = 0;
        private int negativePointsPerMissedApple;

        protected Level
            (int slowActionGame, int snakeLevelLength, int applesToBeEaten, int negativePointsPerMissedApple)
        {
            this.SlowActionGame = slowActionGame;
            this.InitialSnakeLevelLength = snakeLevelLength;
            this.ApplesToBeEaten = applesToBeEaten;
            this.NegativePointsPerMissedApple = negativePointsPerMissedApple;
            this.levelPoints = new Points(snakeLevelLength);
        }

        public IApple Apple { get => this.apple; }

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

        public int ApplesToBeEaten
        {
            get => this.applesToBeEaten;
            private set => this.applesToBeEaten = value;
        }

        public int CurrentlyEatenApples
        {
            get => this.currentlyEatenApples;
            set
            {
                if (value != this.currentlyEatenApples + 1)
                {
                    throw new ArgumentException(GlobalConstants.InvalidApplesState);
                }

                this.currentlyEatenApples = value;
            }
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
                Console.SetCursorPosition(this.Apple.AppleColPosition, this.Apple.AppleRowPosition);
                Console.Write(' ');
            }
            this.apple = new Apple();
            this.apple.Print();
            this.LastAppleCreationTime = Environment.TickCount;
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