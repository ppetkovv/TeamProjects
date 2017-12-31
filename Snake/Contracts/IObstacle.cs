namespace SnakeGame.Contracts
{
    public interface IObstacle
    {
        int ObstacleRowPosition { get; }
        int ObstacleColPosition { get; }
        void PrintObstacle();
    }
}