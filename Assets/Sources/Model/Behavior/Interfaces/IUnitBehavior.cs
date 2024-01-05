using static BlockRooms.Model.Cell;

namespace BlockRooms.Model
{
    public interface IUnitBehavior
    {
        LayerPosition Layer { get; }
    }
}