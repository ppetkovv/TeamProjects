using SnakeGame.Common;
using SnakeGame.Contracts;
using SnakeGame.Models;
using System;

namespace SnakeGame.Levels
{
    public class Level : ILevel
    {
        private int slowActionGame;
        private int initialSnakeLevelLength;
        private int applesToBeEaten;
        private int currentlyEatenApples;
        private Random randomNumberGenerator;
        private Position applePosition;
        //////
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
                //if (value != this.currentlyEatenApples + 1)
                //{
                //    throw new ArgumentException(GlobalConstants.InvalidApplesState);
                //}

                this.currentlyEatenApples = value;
            }
        }
        
        public Position ApplePosition => this.applePosition;

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
            this.randomNumberGenerator = new Random();
            this.applePosition = new Position(randomNumberGenerator.Next(0, Console.WindowHeight),
                                             randomNumberGenerator.Next(0, Console.WindowWidth));
            
            Console.SetCursorPosition(ApplePosition.Col, ApplePosition.Row);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write('@');
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