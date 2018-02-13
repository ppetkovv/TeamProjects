namespace SnakeGame.IO.Contracts
{
    public interface IWriter
    {
        void WriteLine(string value);

        void Write(string value);
    }
}
