using SnakeGame.Contracts;
using System;

namespace SnakeGame.Models
{
    public class Obstacle : Position, IObstacle
    {
        public Obstacle(int row, int col) : base(row, col) { }

        //public Obstacle()
        //{
        //    this.randomNumberGeneratorForObstacle = new Random();
        //    this.obstacle = new Position(randomNumberGeneratorForObstacle.Next(2, Console.WindowHeight - 3),
        //                                 randomNumberGeneratorForObstacle.Next(2, Console.WindowWidth - 3));
        //}

        public void PrintObstacle()
        {
            Console.SetCursorPosition(this.Col, this.Row);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write('X');
        }
    }
}