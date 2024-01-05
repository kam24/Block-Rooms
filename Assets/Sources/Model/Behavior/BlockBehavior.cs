namespace BlockRooms.Model
{
    public class BlockBehavior : IUnitBehavior
    {
        public Cell.LayerPosition Layer => Cell.LayerPosition.ImmovableBlock;
    }
}