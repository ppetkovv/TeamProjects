using System;

namespace SnakeGame.Models
{
    public class Obstacle
    {
        private Position singleObstacle;
        private Random randomNumberGenerator;

        public Obstacle()
        {
            this.randomNumberGenerator = new Random();
            this.singleObstacle = new Position(randomNumberGenerator.Next(0, Console.WindowHeight),
                                               randomNumberGenerator.Next(0, Console.WindowWidth));
        }

        public Position SingleObstacle => this.singleObstacle;

        public void PrintObstacle()
        {
            Console.SetCursorPosition(singleObstacle.Col, singleObstacle.Row);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write('X');
        }
    }
}
