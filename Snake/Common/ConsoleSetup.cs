using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace SnakeGame.Common
{
    class ConsoleSetup
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
    }
}