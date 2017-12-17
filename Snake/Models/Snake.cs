using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake.Contracts;

namespace Snake.Models
{
    class Snake : ISnake
    {
        static byte right = 0;
        static byte left = 1;
        static byte down = 2;
        static byte up = 3;

        private static int initialSnakeLength = 5;
        private static Position[] directions = new Position[]
             {
               new Position(0,1),  //right   >
               new Position(0, -1), //left   <
               new Position(1,0), //down     v
               new Position(-1,0) //top      ^
           };
        private Queue<Position> snakeElements;
        private bool isAlive;


        public Snake()
        {
            this.snakeElements = new Queue<Position>();
            for (int i = 0; i <= initialSnakeLength; i++)
            {
                snakeElements.Enqueue(new Position(0, i));
            }
        }

        public bool IsAlive { get => this.isAlive; set => this.isAlive = value; }

        public Queue<Position> SnakeElements { get => snakeElements; }

        public void Move(int direction)
        {
            Position snakeHead = snakeElements.Last();
            Position nextDirection = directions[direction];
            Position snakeNewHead = new Position(snakeHead.Row + nextDirection.Row,
                                                 snakeHead.Col + nextDirection.Col);
            if (snakeElements.Contains(snakeNewHead) || obstacles.Contains(snakeNewHead))
            {
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Game over!");
                int userPoints = (snakeElements.Count - 6) * 100 - negativePoints;
                userPoints = Math.Max(userPoints, 0);
                Console.WriteLine("Your point are: {0}", userPoints);
                return;
            }
            else if (snakeElements.Contains())
            {

            }
            else
            {
                snakeElements.Enqueue(snakeNewHead);
                this.Print();
            }
        }

        public void Print()
        {
            foreach (Position position in snakeElements)
            {
                Console.SetCursorPosition(position.Col, position.Row);
                //Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("*");
            }
        }
    }
}