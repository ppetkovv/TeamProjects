namespace SnakeGame.Contracts
{
    public interface IApple
    {
        int AppleRowPosition { get; }
        int AppleColPosition { get; }
        void PrintApple();
        void EraseApple();
    }
}