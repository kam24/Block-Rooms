using BlockRooms.Model;

public interface IPushable
{
    public IMovable Movement { get; }

    public bool TryPush(Direction direction);
}
