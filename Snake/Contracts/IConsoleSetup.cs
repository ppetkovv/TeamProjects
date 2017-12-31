namespace SnakeGame.Contracts
{
    public interface IConsoleSetup
    {
        void SetupConsole();
        void SlowAction(int milliseconds);
        void CleaningTheConsoleBuffer();
    }
}