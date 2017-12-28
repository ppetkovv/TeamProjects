using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGame.Contracts;

namespace SnakeGame.Models
{
    class Snake : ISnake
    {
        //static byte right = 0;
        //static byte left = 1;
        //static byte down = 2;
        //static byte up = 3;
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

        public Queue<Position> SnakeElements { get => snakeElements; }
        public bool IsAlive { get => this.isAlive; private set => this.isAlive = value; }

        public void Move(int direction, ILevel currentLevel)
        {
            Position snakeHead = snakeElements.Last();
            Position nextDirection = directions[direction];
            Position snakeNewHead = new Position(snakeHead.Row + nextDirection.Row,
                                                 snakeHead.Col + nextDirection.Col);
            this.CheckForCollision(snakeNewHead);
            if (!this.IsAlive)
                return;
            snakeElements.Enqueue(snakeNewHead);
            Console.SetCursorPosition(snakeNewHead.Col, snakeNewHead.Row);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write('*');
            if (snakeNewHead.Col == currentLevel.Apple.AppleColPosition && snakeNewHead.Row == currentLevel.Apple.AppleRowPosition)
            {
                currentLevel.GenerateApple();
                currentLevel.CurrentlyEatenApples += 1;
            }
            else
            {
                Position tail = snakeElements.Dequeue();
                Console.SetCursorPosition(tail.Col, tail.Row);
                Console.Write(' ');
            }
            //this.Print();
            currentLevel.Apple.Print();
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

        private void CheckForCollision(Position newHead)
        {
            if ((this.snakeElements.Contains(newHead)) || newHead.Row < 0 || newHead.Row >= Console.WindowHeight || newHead.Col < 0 || newHead.Col >= Console.WindowWidth)
            {
                this.IsAlive = false;
            }
        }
    }
}