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

        public void Move(int direction, ILevel currentLevel)
        {
            Position snakeHead = snakeElements.Last();
            Position nextDirection = directions[direction];
            Position snakeNewHead = new Position(snakeHead.Row + nextDirection.Row,
                                                 snakeHead.Col + nextDirection.Col);
            this.SnakeBitesItself(snakeNewHead);
            this.SnakeHitsBorder(snakeNewHead);
            if (!this.IsAlive)
            {  
                return;// WHY?
            }
            this.TeleportIfNeeded(snakeNewHead);
            snakeElements.Enqueue(snakeNewHead);
            Console.SetCursorPosition(snakeNewHead.Col, snakeNewHead.Row);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write('*');
            if (snakeNewHead.Col == currentLevel.Apple.AppleColPosition && snakeNewHead.Row == currentLevel.Apple.AppleRowPosition)
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
            //this.Print();
        }
        //Without printing because of lagging !!!
        //public void Print()
        //{
        //    Console.Clear();
        //    foreach (Position position in snakeElements)
        //    {
        //        Console.SetCursorPosition(position.Col, position.Row);
        //        Console.ForegroundColor = ConsoleColor.Green;
        //        Console.Write("*");
        //    }
        //}

        //public bool SnakeBitesItself(Position newHead)
        //{
        //    if(this.snakeElements.Any(elem=>elem.Row==newHead.Row&&elem.Col==newHead.Col))
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        //public bool SnakeHitsWall(Position newHead)
        //{
        //    if (newHead.Row == 1 || newHead.Row == Console.WindowWidth - 2)
        //    {
        //        return true;
        //    }
        //    else if (this.snakeElements.Any(elem => elem.Col == 1 || elem.Col == Console.WindowHeight - 2))
        //    {
        //        return true;
        //    }
        //    return false;
        //}
         
        public void SnakeBitesItself(Position snakeNewHead)
        {
            if (this.snakeElements.Any(elem => elem.Row == snakeNewHead.Row && elem.Col == snakeNewHead.Col))
            {
                this.isAlive = false;
            }
            else
            {
                this.isAlive = true;
            }
        }

        public void SnakeHitsBorder(Position snakeNewHead)
        {
            if (snakeNewHead.Row == 1 || snakeNewHead.Row == Console.WindowHeight - 2)
            {
                this.isAlive = false;
            }
            else if (snakeNewHead.Col == 1 || snakeNewHead.Col == Console.WindowWidth - 2)
            {
                this.isAlive = false;
            }
            else
            {
                this.isAlive = true;
            }
        }

        private void TeleportIfNeeded(Position newHead)
        {
            if (newHead.Col < 0)
            {
                newHead.Col = Console.WindowWidth - 1;
            }
            else if (newHead.Col == Console.WindowWidth)
            {
                newHead.Col = 0;
            }
            else if (newHead.Row < 0)
            {
                newHead.Row = Console.WindowHeight - 1;
            }
            else if (newHead.Row == Console.WindowHeight)
            {
                newHead.Row = 0;
            }
        }
    }
}