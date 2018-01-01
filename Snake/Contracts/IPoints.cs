namespace SnakeGame.Contracts
{
    public interface IPoints
    {
        int SnakeInitialLength { get; }
        int PositivePoints { get; set; }
        int NegativePoints { get; set; }
        int AllPoints { get; }
    }
}