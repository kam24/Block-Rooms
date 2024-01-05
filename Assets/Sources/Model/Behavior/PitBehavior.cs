using static BlockRooms.Model.Cell;

namespace BlockRooms.Model
{
    public class PitBehavior : IPit
    {
        public LayerPosition Layer => LayerPosition.Pit;
    }
}