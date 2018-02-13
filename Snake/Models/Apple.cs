using SnakeGame.Contracts;
using System;

namespace SnakeGame.Models
{
    public class Apple : Position,IPosition, IApple
    {
        public Apple(int row, int col) : base(row, col) { }

        //public Apple()
        //{
        //    this.randomNumberGeneratorForApple = new Random();
        //    this.apple = new Position(randomNumberGeneratorForApple.Next(2, Console.WindowHeight - 3),
        //                                 randomNumberGeneratorForApple.Next(2, Console.WindowWidth - 3));
        //}

        public void PrintApple()
        {
            Console.SetCursorPosition(this.Col, this.Row);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write('@');
        }

        public void EraseApple()
        {
            Console.SetCursorPosition(this.Col, this.Row);
            Console.Write(' ');
        }
    }
}