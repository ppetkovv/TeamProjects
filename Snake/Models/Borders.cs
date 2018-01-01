using System;

namespace SnakeGame.Models
{
    public static class Borders
    {
        public static void PrintBorders()
        {
            for (int i = 1; i < Console.WindowWidth - 1; i++)          //168
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(i, 1);
                Console.Write('X');
                Console.SetCursorPosition(i, Console.WindowHeight - 2);       //38
                Console.Write('X');
            }

            for (int i = 1; i < Console.WindowHeight - 1; i++)   //38
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(1, i);
                Console.Write('X');
                Console.SetCursorPosition(Console.WindowWidth - 2, i);   //168
                Console.Write('X');
            }
        }
    }
}
