using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using SnakeGame.Contracts;
using SnakeGame.Common;
using SnakeGame.Levels;
using SnakeGame.Models;

namespace SnakeGame.Engine
{
    public sealed class SnakeEngine : IEngine
    {
        private static int right = 0;
        private static int left = 1;
        private static int down = 2;
        private static int up = 3;
        private static readonly IEngine SingleInstance = new SnakeEngine();
        private static ISnake snake;


        public static IEngine Instance
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
            for (int i = 1; i <= 10; i++)
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
            Console.Write(Constants.GameMode);
            int gameMode;
            bool isValidGameModeChoosen = Int32.TryParse(Console.ReadLine(), out gameMode);
            while ((!isValidGameModeChoosen) || (gameMode != 1 && gameMode != 2))
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
                case 4:
                    return new FourthLevel();
                case 5:
                    return new FifthLevel();
                case 6:
                    return new SixthLevel();
                case 7:
                    return new SeventhLevel();
                case 8:
                    return new EightLevel();
                case 9:
                    return new NinethLevel();
                case 10:
                    return new TenthLevel();
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
            //////////////////////
            Console.ReadKey();
            while (currentLevel.CurrentlyEatenApples != currentLevel.ApplesTarget)
            {
                if (!snake.IsAlive)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(Constants.GameOver);
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
                    if (((direction == right || direction == left) && (lastCorrectDirection == right || lastCorrectDirection == left))
                        || ((direction == down || direction == up) && (lastCorrectDirection == down || lastCorrectDirection == up)))
                    {
                        direction = lastCorrectDirection;
                    }
                    lastCorrectDirection = direction;
                    ////////////////////////////////////////////////////////////////////////
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