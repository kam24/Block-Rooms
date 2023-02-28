namespace BlockRooms.Model
{
    public class BlockBehavior : ICellBehavior
    {
        public Cell.LayerPosition Layer => Cell.LayerPosition.ImmovableBlock;
    }
}