using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake.Contracts;
using Snake.Common;
using System.Threading;

namespace Snake.Engine
{
    public sealed class SnakeEngine : IEngine
    {
        private static readonly IEngine SingleInstance = new SnakeEngine();
        private static ISnake snake;

        private static int right = 0;
        private static int left = 1;
        private static int down = 2;
        private static int up = 3;

        public static IEngine Instance
        {
            get
            {
                return SingleInstance;
            }
        }

        public void Start()
        {
            //Setting the console font to raster for better representation of the snake!!!
            //Must turn on unsafe code mode from the project properties!!!
            ConsoleSetup.SetupConsole();
            int gameMode = ChooseGameMode();
            this.GameStartPreparation();
            InitializeSnake();
            this.ReadCommand(gameMode);
        }

        private void InitializeSnake()
        {
            snake = new Models.Snake();
        }

        private void GameStartPreparation()
        {
            Console.Clear();
            for (int i = 10; i >= 1; i--)
            {
                Console.Write(string.Format("{0}{1}{2} {3} sec.", new string('\n', 18), new string('\t', 7), Constants.GameStartPreparation, i));
                Thread.Sleep(1000);
                Console.Clear();
            }
        }

        private static int ChooseGameMode()
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



        private void ReadCommand(int gameMode)
        {
            var direction = right;
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    if (direction == left)
                    {
                        if (direction != right)
                        {
                            direction = left;
                        }
                    }
                    if (direction == right)
                    {
                        if (direction != left)
                        {
                            direction = right;
                        }
                    }
                    if (direction == up)
                    {
                        if (direction != down)
                        {
                            direction = up;
                        }
                    }
                    if (direction == down)
                    {
                        if (direction != up)
                        {
                            direction = down;
                        }
                    }
                }
                else
                {
                    var currentCommand = Console.ReadKey();                    
                    if (gameMode == 1)
                    {
                        direction = GameModeOneKeyParser(currentCommand);
                    }
                    else
                    {
                        direction = GameModeTwoKeyParser(currentCommand);
                    }
                }
                
                this.ProcessCommand(direction);
            }
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

        private void ProcessCommand(int direction)
        {
            snake.Move(direction);
        }
    }
}