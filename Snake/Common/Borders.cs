using System;

namespace SnakeGame.Common
{
    public static class Borders
    {
        public static void PrintBorders()
        {
            for (int i = 1; i < Console.WindowWidth - 1; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(i, 1);
                Console.Write('X');
                Console.SetCursorPosition(i, Console.WindowHeight - 2);
                Console.Write('X');
            }

            for (int i = 1; i < Console.WindowHeight - 1; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(1, i);
                Console.Write('X');
                Console.SetCursorPosition(Console.WindowWidth - 2, i);
                Console.Write('X');
            }
        }
    }
}
