using System;
using System.Text;
using System.Threading;

namespace SnakeGame.Common
{
    public class ConsoleSetup
    {
        public static void SetupConsole()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.SetWindowSize(170, 40);
            Console.BufferHeight = Console.WindowHeight;
            Console.CursorVisible = false;
        }

        public static void SlowAction(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }

        public static void CleaningTheConsoleBuffer()
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
        }
    }
}