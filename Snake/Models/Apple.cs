using SnakeGame.Contracts;
using System;

namespace SnakeGame.Models
{
    public class Apple : IApple
    {
        private Position apple;
        private Random randomNumberGeneratorForApple;

        public Apple()
        {
            this.randomNumberGeneratorForApple = new Random();
            this.apple = new Position(randomNumberGeneratorForApple.Next(2, Console.WindowHeight - 3),
                                         randomNumberGeneratorForApple.Next(2, Console.WindowWidth - 3));
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