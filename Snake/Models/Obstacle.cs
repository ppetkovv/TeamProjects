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
            this.obstacle = new Position(randomNumberGeneratorForObstacle.Next(0, Console.WindowHeight),
                                         randomNumberGeneratorForObstacle.Next(0, Console.WindowWidth));
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
