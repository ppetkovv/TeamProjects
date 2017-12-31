using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGame.Contracts;

namespace SnakeGame.Models
{
    public class Apple : IApple
    {
        private Position apple;
        private Random randomNumberGenerator;

        public Apple()
        {
            this.randomNumberGenerator = new Random();
            this.apple = new Position(randomNumberGenerator.Next(0, Console.WindowHeight),
                                         randomNumberGenerator.Next(0, Console.WindowWidth));
        }

        public int AppleColPosition => this.apple.Col;
        public int AppleRowPosition => this.apple.Row;

        public void PrintApple()
        {
            Console.SetCursorPosition(apple.Col, apple.Row);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write('@');
        }

        public void EraseApple()
        {
            Console.SetCursorPosition(apple.Col, apple.Row);
            Console.Write(' ');
        }
    }
}