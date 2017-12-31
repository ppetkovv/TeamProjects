using SnakeGame.Common;
using SnakeGame.Contracts;
using SnakeGame.Levels;
using SnakeGame.Models;
using System;

namespace SnakeGame.Engine
{
    public sealed class SnakeEngine : ISnakeEngine // why is this sealed?
    {
        private const int firstLevelIndex = 1;
        private const int lastLevelIndex = 7;
        private const int firstGameMode = 1;
        private const int secondGameMode = 2;
        private const int initialSecond = 5;
        private const int finalSecond = 1;
        private static IPoints gamePoints;

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

            InitializeGamePoints();
            for (int i = firstLevelIndex; i <= lastLevelIndex; i++)
            {
                ILevel currentLevel = LevelGenerator(i);
                this.GameStartPreparation(i);
                this.InitializeSnake(currentLevel);
                currentLevel.GenerateApple();
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
                   (gameMode != firstGameMode && gameMode != secondGameMode))
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
            for (int i = initialSecond; i >= finalSecond; i--)
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

        private void InitializeGamePoints()
        {
            gamePoints = new Points();
        }

        private void ReadCommand(int gameMode, ILevel currentLevel)
        {
            //Cleaning the console buffer, because of incorrect start direction!!!
            ConsoleSetup.CleaningTheConsoleBuffer();

            int direction = (int) Directions.right;
            int lastCorrectDirection = direction;
            while (currentLevel.CurrentlyEatenApples != currentLevel.ApplesToBeEaten)
            {
                //if (!snake.IsAlive)
                //{
                //    Console.SetCursorPosition(0, 0);
                //    Console.ForegroundColor = ConsoleColor.White;
                //    Console.WriteLine(GlobalConstants.GameOver);
                //    Environment.Exit(-1);
                //}
                CheckingWhetherSnakeIsAlive(currentLevel);
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
                    //Checking and ignoring direction if incorrect key is pressed !!!
                    //Checking and ingnoring direction if opposite direction is choosen !!!
                    CheckingCurrentDirection(ref direction, ref lastCorrectDirection);
                }
                ConsoleSetup.SlowAction(currentLevel.SlowActionGame);
                this.ProcessCommand(direction, currentLevel);
            }

            gamePoints.PositivePoints += currentLevel.AllLevelPoints;
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

        private static void CheckingWhetherSnakeIsAlive(ILevel currentLevel)
          {
              if (!snake.IsAlive)
              {
                  gamePoints.PositivePoints += currentLevel.AllLevelPoints;
                  Console.SetCursorPosition(0, 0);
                  Console.ForegroundColor = ConsoleColor.White;
                  Console.WriteLine(GlobalConstants.GameOver);
                  Console.WriteLine($"Total points: {gamePoints.AllPoints}");
                  Environment.Exit(-1);
              }
          }
  
          private static void CheckingCurrentDirection(ref int direction, ref int lastCorrectDirection)
          {
              direction = direction != -1 ? direction : lastCorrectDirection;
              if (((direction == (int) Directions.right || direction == (int)Directions.left) &&
                   (lastCorrectDirection == (int)Directions.right || lastCorrectDirection == (int)Directions.left)) || 
                  ((direction == (int)Directions.down || direction == (int)Directions.up) && 
                   (lastCorrectDirection == (int)Directions.down || lastCorrectDirection == (int)Directions.up)))
              {
                  direction = lastCorrectDirection;
              }
              lastCorrectDirection = direction;
          }

    }
}