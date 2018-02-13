using SnakeGame.Common;
using SnakeGame.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SnakeGame.Models
{
    public class Snake : ISnake
    {
        private Queue<IPosition> snakeElements;
        private bool isAlive;

        public Snake(int length)
        {
            this.isAlive = true;
            this.snakeElements = new Queue<IPosition>(length);
            for (int i = 5; i < length + 5; i++)
            {
                snakeElements.Enqueue(new Position((Console.WindowHeight / 2), i));
            }
        }

        public Queue<IPosition> SnakeElements { get => this.snakeElements; }
        public bool IsAlive { get => this.isAlive; private set => this.isAlive = value; }

        public void Move(string direction, ILevel currentLevel, IList<IObstacle> Obstacles)
        {
            IPosition snakeHead = snakeElements.Last();
            IPosition nextDirection = Constants.positionsByIndex[direction];
            IPosition snakeNewHead = new Position(snakeHead.Row + nextDirection.Row,
                                                 snakeHead.Col + nextDirection.Col);

            this.isAlive = !this.SnakeBitesItself(snakeNewHead);
            if (!this.IsAlive)
            {
                return;
            }

            this.isAlive = !this.SnakeHitsBorder(snakeNewHead);
            if (!this.IsAlive)
            {
                return;
            }

            this.isAlive = !this.SnakeHitsObstacle(snakeNewHead, Obstacles);
            if (!this.IsAlive)
            {
                return;
            }

            snakeElements.Enqueue(snakeNewHead);
            Console.SetCursorPosition(snakeNewHead.Col, snakeNewHead.Row);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write('*');

            if (snakeNewHead.Col == currentLevel.Apple.Col &&
                snakeNewHead.Row == currentLevel.Apple.Row)
            {
                currentLevel.GenerateApple(currentLevel.Obstacles);
                currentLevel.CurrentlyEatenApples += 1;
                currentLevel.AddPoints();
                Thread.Sleep(19);
                currentLevel.GenerateObstacle();
            }
            else
            {
                IPosition tail = snakeElements.Dequeue();
                Console.SetCursorPosition(tail.Col, tail.Row);
                Console.Write(' ');
            }
        }

        private bool SnakeBitesItself(IPosition snakeNewHead)
        {
            return (this.snakeElements.Any(elem => elem.Row == snakeNewHead.Row &&
                                                   elem.Col == snakeNewHead.Col));
        }

        private bool SnakeHitsBorder(IPosition snakeNewHead)
        {
            return (snakeNewHead.Row == 1 || snakeNewHead.Row == Console.WindowHeight - 2 ||
                    snakeNewHead.Col == 1 || snakeNewHead.Col == Console.WindowWidth - 2);
        }

        private bool SnakeHitsObstacle(IPosition snakeNewHead, IList<IObstacle> obstacles)
        {
            return (obstacles.Any(x => x.Row == snakeNewHead.Row &&
                                       x.Col == snakeNewHead.Col));
        }
    }
}