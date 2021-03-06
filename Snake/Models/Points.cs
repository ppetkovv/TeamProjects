﻿using SnakeGame.Contracts;
using System;

namespace SnakeGame.Models
{
    public class Points : IPoints
    {
        private int positivePoints;
        private int negativePoints;
        private int snakeInitialLength;

        public Points(int snakeInitialLength)
        {
            if(snakeInitialLength < 0)
            {
                throw new ArgumentException();
            }
            this.SnakeInitialLength = snakeInitialLength;
        }

        public int PositivePoints { get => this.positivePoints; set => this.positivePoints = value; }
        public int NegativePoints { get => this.negativePoints; set => this.negativePoints = value; }
        public int AllPoints { get => this.positivePoints - this.negativePoints < 0 ? 0 : this.positivePoints - this.negativePoints;}
        public int SnakeInitialLength { get => this.snakeInitialLength; private set => this.snakeInitialLength = value; }
    }
}