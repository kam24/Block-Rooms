using BlockRooms.Model;

public interface IPushable
{
    IMovable Movement { get; }

    public bool TryPush(Direction direction);
}
