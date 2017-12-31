using SnakeGame.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeGame.Models
{
    public class Snake : ISnake
    {
        private Queue<Position> snakeElements;
        private bool isAlive = true;

        private Position[] directions = new Position[]
        {
               new Position(0,1),  //right
               new Position(0, -1), //left
               new Position(1,0), //down
               new Position(-1,0) //top
        };

        public Snake(int length)
        {
            this.snakeElements = new Queue<Position>(length);
            for (int i = 0; i < length; i++)
            {
                snakeElements.Enqueue(new Position(0, i));
            }
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
            {
                return;         // pls remake
            }
                
            snakeElements.Enqueue(snakeNewHead);
            Console.SetCursorPosition(snakeNewHead.Col, snakeNewHead.Row);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write('*');
            if ((snakeNewHead.Col == currentLevel.ApplePosition.Col) && 
                (snakeNewHead.Row == currentLevel.ApplePosition.Row))
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
        }

        private void CheckForCollision(Position newHead)
        {
            if ((this.snakeElements.Contains(newHead)) ||
                 newHead.Row < 0 ||
                 newHead.Row >= Console.WindowHeight ||
                 newHead.Col < 0 ||
                 newHead.Col >= Console.WindowWidth)
            {
                this.IsAlive = false;
            }
        }

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
        
}