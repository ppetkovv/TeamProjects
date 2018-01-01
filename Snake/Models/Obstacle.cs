using SnakeGame.Contracts;
using System;

namespace SnakeGame.Models
{
    public class Obstacle : IObstacle
    {
        private Position obstacle;
        private Random randomNumberGeneratorForObstacle;

        public Obstacle()
        {
            this.randomNumberGeneratorForObstacle = new Random();
            this.obstacle = new Position(randomNumberGeneratorForObstacle.Next(2, Console.WindowHeight - 3),
                                         randomNumberGeneratorForObstacle.Next(2, Console.WindowWidth - 3));
        }

        public int ObstacleColPosition => this.obstacle.Col;
        public int ObstacleRowPosition => this.obstacle.Row;

        public void PrintObstacle()
        {
            Console.SetCursorPosition(obstacle.Col, obstacle.Row);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write('X');
        }
    }
}
