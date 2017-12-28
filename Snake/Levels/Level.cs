using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGame.Contracts;
using SnakeGame.Models;
using SnakeGame.Common;

namespace SnakeGame.Levels
{
    public abstract class Level : ILevel
    {
        private int slowActionGame;
        private int initialSnakeLevelLength;
        private int applesTarget;
        private int currentlyEatenApples;
        private IApple apple;

        protected Level(int slowActionGame, int snakeLevelLength, int applesTarget)
        {
            this.SlowActionGame = slowActionGame;
            this.InitialSnakeLevelLength = snakeLevelLength;
            this.ApplesTarget = applesTarget;
        }

        public int SlowActionGame { get => this.slowActionGame; private set => this.slowActionGame = value; }
        public int InitialSnakeLevelLength { get => this.initialSnakeLevelLength; private set => this.initialSnakeLevelLength = value; }
        public int ApplesTarget { get => this.applesTarget; private set => this.applesTarget = value; }
        public int CurrentlyEatenApples { get => this.currentlyEatenApples; set { if (value != this.currentlyEatenApples + 1) { throw new ArgumentException(Constants.InvalidApplesState); } this.currentlyEatenApples = value; } }
        public IApple Apple { get => this.apple; }

        public void GenerateApple()
        {
            this.apple = new Apple();
        }
    }
}