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
        private bool isAlive;

        public Snake(int length)
        {
            this.snakeElements = new Queue<Position>(length);
            for (int i = 0; i < length; i++)
            {
                snakeElements.Enqueue(new Position(0, i));
            }
            this.isAlive = true;
        }

        public Queue<Position> SnakeElements { get => this.snakeElements; }
        public bool IsAlive { get => this.isAlive; private set => this.isAlive = value; }

        public void Move(int direction, ILevel currentLevel)
        {
            Position snakeHead = snakeElements.Last();
            Position nextDirection = directions[direction];
            Position snakeNewHead = new Position(snakeHead.Row + nextDirection.Row,
                                                 snakeHead.Col + nextDirection.Col);
            this.DoesSnakeBiteItself(snakeNewHead);
            if (!this.IsAlive)
            {
                return;         // WHY?
            }
            this.TeleportIfIsNeeded(snakeNewHead);
            snakeElements.Enqueue(snakeNewHead);
            Console.SetCursorPosition(snakeNewHead.Col, snakeNewHead.Row);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write('*');
            if (snakeNewHead.Col == currentLevel.Apple.AppleColPosition && snakeNewHead.Row == currentLevel.Apple.AppleRowPosition)
            {
                currentLevel.GenerateApple();
                currentLevel.CurrentlyEatenApples += 1;
                currentLevel.AddPoints();
                Thread.Sleep(13);
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

        public void DoesSnakeBiteItself(Position newHead)
        {
            if(this.snakeElements.Any(elem=>elem.Row==newHead.Row&&elem.Col==newHead.Col))
            {
                this.isAlive = false;
            }
        }

        private void TeleportIfIsNeeded(Position newHead)
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