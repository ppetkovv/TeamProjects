using SnakeGame.IO.Contracts;
using System;

namespace SnakeGame.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}