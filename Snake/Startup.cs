using SnakeGame.Contracts;
using SnakeGame.Engine;
using SnakeGame.IO;
using SnakeGame.IO.Contracts;

namespace SnakeGame
{
    public class Startup
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IEngine engine = new GameEngine(reader,writer);
            engine.Start();
        }
    }
}