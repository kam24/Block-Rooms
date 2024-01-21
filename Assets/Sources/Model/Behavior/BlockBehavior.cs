namespace BlockRooms.Model
{
    public class BlockBehavior : IUnitBehavior
    {
        public UnitLayer Layer => UnitLayer.ImmovableBlock;
    }
}