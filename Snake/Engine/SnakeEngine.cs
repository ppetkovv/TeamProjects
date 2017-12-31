using SnakeGame.Common;
using SnakeGame.Contracts;
using SnakeGame.Levels;
using SnakeGame.Models;
using System;

namespace SnakeGame.Engine
{
    public sealed class SnakeEngine : ISnakeEngine // why is this sealed?
    {
        private static readonly ISnakeEngine SingleInstance = new SnakeEngine();
        private static ISnake snake;
        
        public static ISnakeEngine Instance
        {
            get
            {
                return SingleInstance;
            }
        }

        public void Start()
        {
            ConsoleSetup.SetupConsole();
            int gameMode = this.ChooseGameMode();
            for (int i = 1; i <= 7; i++)
            {
                ILevel currentLevel = LevelGenerator(i);
                this.GameStartPreparation(i);
                currentLevel.GenerateApple();
                this.InitializeSnake(currentLevel);
                this.ReadCommand(gameMode, currentLevel);
            }
            Console.SetCursorPosition(0, 0);
        }

        private int ChooseGameMode()
        {
            Console.Write(GlobalConstants.GameMode);
            int gameMode;
            bool isValidGameModeChoosen = Int32.TryParse(Console.ReadLine(), out gameMode);
            while ((!isValidGameModeChoosen) || 
                   (gameMode != 1 && gameMode != 2))
            {
                Console.Write(GlobalConstants.InvalidGameMode);
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
                case 4:
                    return new FourthLevel();
                case 5:
                    return new FifthLevel();
                case 6:
                    return new SixthLevel();
                case 7:
                    return new SeventhLevel();
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
            for (int i = 5; i >= 1; i--)
            {
                Console.Write($"{stringOfNewLines}{stringOfTabulationsForLevel}");
                Console.WriteLine($"{GlobalConstants.GameLevel} {level}");
                Console.Write($"\n{stringOfTabulationsForTime}");
                Console.Write($"{GlobalConstants.GameStartPreparation} {i} sec.");
                ConsoleSetup.SlowAction(1000);
                Console.Clear();
            }
        }

        private void InitializeSnake(ILevel currentLevel)
        {
            snake = new Snake(currentLevel.InitialSnakeLevelLength);
        }

        private void ReadCommand(int gameMode, ILevel currentLevel)
        {
            int direction = 0;
            int lastCorrectDirection = direction;
            //Code for safety at the beggining of each level!!!
            //Cleaning the console buffer!!!
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }

            Console.ReadKey();
            while (currentLevel.CurrentlyEatenApples != currentLevel.ApplesToBeEaten)
            {
                if (!snake.IsAlive)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(GlobalConstants.GameOver);
                    Environment.Exit(-1);
                }
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
                    //Checking and ignoring direction if incorrect key is pressed !!!
                    //Checking and ingnoring direction if opposite direction is choosen !!!
                    direction = direction != -1 ? direction : lastCorrectDirection;
                    if (((direction == (int) Directions.right || direction == (int)Directions.left) &&
                         (lastCorrectDirection == (int)Directions.right || lastCorrectDirection == (int)Directions.left)) || 
                        ((direction == (int)Directions.down || direction == (int)Directions.up) && 
                         (lastCorrectDirection == (int)Directions.up || lastCorrectDirection == (int)Directions.up)))
                    {
                        direction = lastCorrectDirection;
                    }
                    lastCorrectDirection = direction;
                }
                ConsoleSetup.SlowAction(currentLevel.SlowActionGame);
                this.ProcessCommand(direction, currentLevel);
            }
        }

        private void ProcessCommand(int direction, ILevel curentLevel)
        {
            snake.Move(direction, curentLevel);
        }

        private int GameModeOneKeyParser(ConsoleKeyInfo currentCommand)
        {
            switch (currentCommand.Key)
            {
                case ConsoleKey.W:
                    return 3;
                case ConsoleKey.S:
                    return 2;
                case ConsoleKey.A:
                    return 1;
                case ConsoleKey.D:
                    return 0;
                default:
                    return -1;
            }
        }

        private int GameModeTwoKeyParser(ConsoleKeyInfo currentCommand)
        {
            switch (currentCommand.Key)
            {
                case ConsoleKey.UpArrow:
                    return 3;
                case ConsoleKey.DownArrow:
                    return 2;
                case ConsoleKey.LeftArrow:
                    return 1;
                case ConsoleKey.RightArrow:
                    return 0;
                default:
                    return -1;
            }
        }
    }
}