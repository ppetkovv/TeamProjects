using SnakeGame.Common;
using SnakeGame.Contracts;
using SnakeGame.IO.Contracts;
using SnakeGame.Levels;
using SnakeGame.Models;
using System;
using System.Collections.Generic;

namespace SnakeGame.Engine
{
    public sealed class GameEngine : IEngine
    {
        private const int firstLevelIndex = 1;
        private const int lastLevelIndex = 3;

        private const int firstGameMode = 1;
        private const int secondGameMode = 2;

        private const int initialSecond = 5;
        private const int finalSecond = 1;

        private static ISnake snake;
        private static IPoints gamePoints;

        private IReader reader;
        private IWriter writer;

        public GameEngine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Start()
        {
            ConsoleSetup.SetupConsole();
            int gameMode = this.ChooseGameMode();

            for (int i = firstLevelIndex; i <= lastLevelIndex; i++)
            {
                ILevel currentLevel = LevelGenerator(i);
                this.GameStartPreparation(i);
                this.InitializeSnake(currentLevel);
                this.InitializeGamePoints(currentLevel);
                currentLevel.GenerateApple();
                this.ReadCommand(gameMode, currentLevel);
            }
        }

        private int ChooseGameMode()
        {
            Console.Write(Constants.GameMode);
            bool isValidGameModeChoosen = Int32.TryParse(Console.ReadLine(), out int gameMode);
            while ((!isValidGameModeChoosen) || 
                   (gameMode != firstGameMode && gameMode != secondGameMode))
            {
                Console.Write(Constants.InvalidGameMode);
                isValidGameModeChoosen = Int32.TryParse(Console.ReadLine(), out gameMode);
            }

            return gameMode;
        }

        private ILevel LevelGenerator(int levelAsNumber)
        {
            switch (levelAsNumber)
            {
                case 1:
                    return new FirstLevel();
                case 2:
                    return new SecondLevel();
                case 3:
                    return new ThirdLevel();
                default:
                    throw new NotImplementedException();
            }
        }

        private void GameStartPreparation(int level)
        {
            Console.Clear();
            string stringOfNewLines = new string('\n', 18);
            string stringOfTabulationsForLevel = new string('\t', 9);
            string stringOfTabulationsForTime = new string('\t', 7);
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = initialSecond; i >= finalSecond; i--)
            {
                Console.Write($"{stringOfNewLines}{stringOfTabulationsForLevel}");
                Console.WriteLine($"{Constants.GameLevel} {level}");
                Console.Write($"\n{stringOfTabulationsForTime}");
                Console.Write($"{Constants.GameStartPreparation} {i} sec.");
                ConsoleSetup.SlowAction(1000);
                Console.Clear();
            }
        }

        private void InitializeSnake(ILevel currentLevel)
        {
            snake = new Snake(currentLevel.InitialSnakeLevelLength);
        }

        private void InitializeGamePoints(ILevel currentLevel)
        {
            gamePoints = new Points(currentLevel.InitialSnakeLevelLength);
        }

        private void ReadCommand(int gameMode, ILevel currentLevel)
        {
            ConsoleSetup.CleaningTheConsoleBuffer();

            string direction = "right";
            string lastCorrectDirection = direction;

            while (currentLevel.CurrentlyEatenApples != currentLevel.ApplesTarget)
            {
                IsGameOver(currentLevel);
                Borders.PrintBorders();
                currentLevel.CheckForAppleTimeElapsed();
                if (Console.KeyAvailable)
                {
                    var currentCommand = Console.ReadKey(true);
                    if (gameMode == 1)
                    {
                        direction = GameModeOneKeyParser(currentCommand);
                    }
                    else
                    {
                        direction = GameModeTwoKeyParser(currentCommand);
                    }
                    //Checking and ignoring direction if incorrect key is pressed +
                    //Checking and ingnoring direction if opposite direction is chosen
                    CheckingCurrentDirection(ref direction, ref lastCorrectDirection);
                }
                ConsoleSetup.SlowAction(currentLevel.SlowActionGame);
                this.ProcessCommand(direction, currentLevel, currentLevel.Obstacles);
            }
            gamePoints.PositivePoints += currentLevel.AllLevelPoints;
        }


        private void ProcessCommand(string direction, ILevel curentLevel, IList<IObstacle> obstacles)
        {
            snake.Move(direction, curentLevel, obstacles);
        }

        private string GameModeOneKeyParser(ConsoleKeyInfo currentCommand)
        {
            switch (currentCommand.Key)
            {
                case ConsoleKey.W:
                    return "up";
                case ConsoleKey.S:
                    return "down";
                case ConsoleKey.A:
                    return "left";
                case ConsoleKey.D:
                    return "right";
                default:
                    return "Vari na mainata si";
            }
        }

        private string GameModeTwoKeyParser(ConsoleKeyInfo currentCommand)
        {
            switch (currentCommand.Key)
            {
                case ConsoleKey.UpArrow:
                    return "up";
                case ConsoleKey.DownArrow:
                    return "down";
                case ConsoleKey.LeftArrow:
                    return "left";
                case ConsoleKey.RightArrow:
                    return "right";
                default:
                    return "Vari na mainata si";
            }
        }

        private static void IsGameOver(ILevel currentLevel)
        {
            if (!snake.IsAlive)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.SetCursorPosition((Console.BufferWidth / 2) - Constants.GameOver.Length, 
                                           Console.BufferHeight / 2);
                Console.WriteLine(Constants.GameOver);
                string pointsMessage = $"Total points: {gamePoints.AllPoints}";
                Console.SetCursorPosition((Console.BufferWidth / 2) - pointsMessage.Length + 1, 
                                           Console.BufferHeight / 2 + 1);
                Console.WriteLine(pointsMessage);
                Console.SetCursorPosition((Console.BufferWidth / 2) - 20, 
                                           Console.BufferHeight / 2 + 2);
                Environment.Exit(-1);
            }
        }

        private static void CheckingCurrentDirection(ref string direction, ref string lastCorrectDirection)
        {

            direction = direction != "Vari na mainata si" ? direction : lastCorrectDirection;
            if (((direction == "right" || direction == "left") &&
                 (lastCorrectDirection == "right" || lastCorrectDirection == "left")) ||
                ((direction == "down" || direction == "up") &&
                (lastCorrectDirection == "down" || lastCorrectDirection == "up")))
            {
                direction = lastCorrectDirection;
            }
            lastCorrectDirection = direction;
        }
    }
}