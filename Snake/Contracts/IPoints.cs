namespace SnakeGame.Contracts
{
    public interface IPoints
    {
        int PositivePoints { get; set; }
        int NegativePoints { get; set; }
        int SnakeInitialLength { get; }
        int AllPoints { get; }
    }
}