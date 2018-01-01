using SnakeGame.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SnakeGame.Models
{
    public class Snake : ISnake
    {
        private static Position[] directions = new Position[]
        {
               new Position(0,1),  //right
               new Position(0, -1), //left
               new Position(1,0), //down
               new Position(-1,0) //top
        };

        private Queue<Position> snakeElements;
        private bool isAlive = true;

        public Snake(int length)
        {
            this.snakeElements = new Queue<Position>(length);
            for (int i = 5; i < length + 5; i++)
            {
                snakeElements.Enqueue(new Position((Console.WindowHeight / 2), i));
            }
        }

        public Queue<Position> SnakeElements { get => this.snakeElements; }
        public bool IsAlive { get => this.isAlive; private set => this.isAlive = value; }

        public void Move(int direction, ILevel currentLevel, IList<IObstacle> Obstacles)
        {
            Position snakeHead = snakeElements.Last();
            Position nextDirection = directions[direction];
            Position snakeNewHead = new Position(snakeHead.Row + nextDirection.Row,
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

            if (snakeNewHead.Col == currentLevel.Apple.AppleColPosition && 
                snakeNewHead.Row == currentLevel.Apple.AppleRowPosition)
            {
                currentLevel.GenerateApple();
                currentLevel.CurrentlyEatenApples += 1;
                currentLevel.AddPoints();
                Thread.Sleep(19);
                currentLevel.GenerateObstacle();
            }
            else
            {
                Position tail = snakeElements.Dequeue();
                Console.SetCursorPosition(tail.Col, tail.Row);
                Console.Write(' ');
            }
        }

        public bool SnakeBitesItself(Position snakeNewHead)
        {
            return (this.snakeElements.Any(elem => elem.Row == snakeNewHead.Row && 
                                                   elem.Col == snakeNewHead.Col));
        }

        public bool SnakeHitsBorder(Position snakeNewHead)
        {
            return (snakeNewHead.Row == 1 || snakeNewHead.Row == Console.WindowHeight - 2 ||
                    snakeNewHead.Col == 1 || snakeNewHead.Col == Console.WindowWidth - 2);
        }

        public bool SnakeHitsObstacle(IPosition snakeNewHead, IList<IObstacle> obstacles)
        {
            return (obstacles.Any(x => x.ObstacleRowPosition == snakeNewHead.Row && 
                                       x.ObstacleColPosition == snakeNewHead.Col));
        }
    }
}