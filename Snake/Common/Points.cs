﻿using SnakeGame.Contracts;

namespace SnakeGame.Common
{
    class Points : IPoints
    {
        private int positivePoints;
        private int negativePoints;
        private int snakeInitialLength;

        public Points() { }

        public Points(int snakeInitialLength)
        {
            this.SnakeInitialLength = snakeInitialLength;
        }

        public int PositivePoints { get => this.positivePoints; set => this.positivePoints = value; }
        public int NegativePoints { get => this.negativePoints; set => this.negativePoints = value; }
        public int SnakeInitialLength
        {
            get => this.snakeInitialLength;
            private set => this.snakeInitialLength = value;
        }

        public int AllPoints
        {
            get => this.positivePoints - this.negativePoints < 0 ? 0 : this.positivePoints - this.negativePoints;
        }
    }
}