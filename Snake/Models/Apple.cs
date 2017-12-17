using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake.Contracts;

namespace Snake.Models
{
    class Apple : IApple
    {
        private Position apple;
        private Random randomNumberGenerator = new Random();

        public void GenerateApple(ISnake snakeForChecking)
        {
            do
            {
                apple = new Position(randomNumberGenerator.Next(0, Console.WindowHeight),
                                         randomNumberGenerator.Next(0, Console.WindowWidth));
            } while (snakeForChecking.SnakeElements.Contains(apple) || obstacles.Contains(apple));

            Console.SetCursorPosition(apple.Col, apple.Row);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("@");
        }

        public void Print()
        {
            Console.SetCursorPosition(apple.Col, apple.Row);
            Console.Write('@');
        }

    }
}